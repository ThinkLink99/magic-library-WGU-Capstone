using mtg_library.Models;
using SQLite;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace mtg_library.Data
{
    public class DataContext : IDataContext, IDisposable
    {
        private readonly SQLiteAsyncConnection _database;
        private bool _disposed;

        public DataContext()
        {
             var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyData.db");
            _database = new SQLiteAsyncConnection(databasePath);
            try
            {
                //_database.CreateTableAsync<Card>().Wait();
                _database.CreateTableAsync<Library>().Wait();
                _database.CreateTableAsync<LibraryCard>().Wait();

                PopulateMockData();

                if (false)
                {
                    _database.DeleteAllAsync<Library>().Wait();
                    _database.DeleteAllAsync<LibraryCard>().Wait();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }

        private async Task PopulateMockData ()
        {
            if ((await RetrieveLibrariesAsync()).Count > 0) { return; }

            UserPrefs.Instance.ActiveLibraryId = await CreateLibraryAsync(DateTime.Now, "active");
        }

        /* Card CRUD Operations */

        /* Library CRUD Operations */
        public async Task<Guid> CreateLibraryAsync(DateTime createDate, string status) 
        {
            var lib = new Library() { Id = Guid.NewGuid(), Name = "New Library", CreatedDate = createDate, Status = status, LastUpdated = createDate };
            await _database.InsertAsync(lib);
            return lib.Id;
        }
        public async Task<Library> RetrieveLibraryAsync(string libraryId) 
        {
            var ret = await _database.Table<Library>().ToListAsync();
            var lib = ret.Where(L => L.Id == Guid.Parse(libraryId)).FirstOrDefault();
            return lib;
        }
        public async Task<List<Library>> RetrieveLibrariesAsync() 
        { 
            return await _database.Table<Library>().ToListAsync();
        }
        public async Task<int> UpdateLibraryAsync(Library library) 
        {
            return await _database.UpdateAsync(library);
        }
        public async Task<int> DeleteLibraryAsync(string libraryId) 
        {
            return await _database.DeleteAsync<Library>(libraryId);
        }

        /* LibraryCard CRUD Operations */
        public async Task<int> CreateLibraryCardAsync(string libraryId, string cardId) 
        {
            return await _database.InsertAsync(new LibraryCard() { LibraryId = Guid.Parse(libraryId), CardId = Guid.Parse(cardId) });
        }
        public async Task<int> CreateLibraryCardAsync(string libraryId, string cardId, int quantity)
        {
            return await _database.InsertAsync(new LibraryCard() { LibraryId = Guid.Parse(libraryId), CardId = Guid.Parse(cardId), Quantity = quantity });
        }
        public async Task<bool> LibraryCardExists(string libraryId, string cardId)
        {
            return (await _database.Table<LibraryCard>().ToListAsync())
                                  .Where(L => L.LibraryId == Guid.Parse(libraryId) &&
                                              L.CardId == Guid.Parse(cardId))
                                  .Any();
        }
        public async Task<LibraryCard> RetrieveLibraryCardAsync(string libraryId, string cardId) 
        { 
            return (await _database.Table<LibraryCard>().ToListAsync())
                                  .Where(L => L.LibraryId == Guid.Parse(libraryId) && 
                                              L.CardId == Guid.Parse(cardId))
                                  .FirstOrDefault();
        }
        public async Task<List<LibraryCard>> RetrieveLibraryCardsAsync(string libraryId) 
        {
            return (await _database.Table<LibraryCard>().ToListAsync())
                                  .Where(L => L.LibraryId == Guid.Parse(libraryId))
                                  .ToList();
        }
        public async Task<int> UpdateLibraryCardAsync(LibraryCard libraryCard) 
        { 
            return await _database.UpdateAsync(libraryCard);
        }
        public Task<int> DeleteLibraryCardAsync(string libraryId, string cardId) 
        { 
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;
        }
    }
}
