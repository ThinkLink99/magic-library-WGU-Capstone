using mtg_library.Data;
using mtg_library.Models;
using mtg_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace mtg_library.ViewModels
{
    public class LibraryPageViewModel : BaseViewModel
    {
        private readonly ScryfallService scryfallService;
        private readonly IDataContext context;
        private ObservableCollection<Library> libraries;
        public ObservableCollection<Library> Libraries
        {
            get => libraries;
            set
            {
                libraries = value;
                OnPropertyChanged(nameof(Libraries));
            }
        }

        public LibraryPageViewModel(ScryfallService scryfallService, IDataContext context)
        {
            this.scryfallService = scryfallService;
            this.context = context;
            Libraries = new ObservableCollection<Library>();
        }

        public async Task CreateNewLibrary()
        {
            await context.CreateLibraryAsync(DateTime.Now, "active");
        }
        public async Task LoadLibraries()
        {
            Libraries.Clear();
            var l = await context.RetrieveLibrariesAsync();
            foreach (var library in l)
            {
                Libraries.Add(library);
            }
        }
    }
}
