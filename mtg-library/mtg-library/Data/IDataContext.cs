using mtg_library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace mtg_library.Data
{
    public interface IDataContext
    {
        /* Card CRUD Operations */

        /* Library CRUD Operations */
        Task<int> CreateLibraryAsync(DateTime createDate, string status);
        Task<Library> RetrieveLibraryAsync(string libraryId);
        Task<List<Library>> RetrieveLibrariesAsync();
        Task<int> UpdateLibraryAsync(Library library);
        Task<int> DeleteLibraryAsync(string libraryId);

        /* LibraryCard CRUD Operations */
        Task<int> CreateLibraryCardAsync (string libraryId, string cardId);
        Task<LibraryCard> RetrieveLibraryCardAsync(string libraryId, string cardId);
        Task<List<LibraryCard>> RetrieveLibraryCardsAsync(string libraryId);
        Task<int> UpdateLibraryCardAsync(LibraryCard libraryCard);
        Task<int> DeleteLibraryCardAsync(string libraryId, string cardId);
    }
}
