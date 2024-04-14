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
    public class DataContext : IDataContext
    {
        private readonly SQLiteAsyncConnection _database;
        public DataContext()
        {
             var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyData.db");
            _database = new SQLiteAsyncConnection(databasePath);
            try
            {
                //_database.CreateTableAsync<Card>().Wait();
                _database.CreateTableAsync<Library>().Wait();
                _database.CreateTableAsync<LibraryCard>().Wait();


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

        /* Card CRUD Operations */

        /* Library CRUD Operations */
        public async Task<int> CreateLibraryAsync(DateTime createDate, string status) 
        { 
            return await _database.InsertAsync(new Library() { Id = Guid.NewGuid(), Name = "New Library", CreatedDate = createDate, Status = status, LastUpdated = createDate });
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
        public Task<int> CreateLibraryCardAsync(string libraryId, string cardId) 
        {
            throw new NotImplementedException();
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
        public Task<int> UpdateLibraryCardAsync(LibraryCard libraryCard) 
        { 
            throw new NotImplementedException();
        }
        public Task<int> DeleteLibraryCardAsync(string libraryId, string cardId) 
        { 
            throw new NotImplementedException();
        }
    }
}
