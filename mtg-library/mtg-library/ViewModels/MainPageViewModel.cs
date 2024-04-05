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
    public class MainPageViewModel : BaseViewModel
    {
        private readonly ScryfallService scryfallService;
        private readonly IDataContext context;
        private ObservableCollection<Card> cards;
        private ObservableCollection<Library> libraries;

        public ObservableCollection<Card> Cards 
        { 
            get => cards; 
            set {
                cards = value;
                OnPropertyChanged(nameof(Cards));
            } 
        }
        public ObservableCollection<Library> Libraries
        {
            get => libraries;
            set
            {
                libraries = value;
                OnPropertyChanged(nameof(Libraries));
            }
        }
        public MainPageViewModel(ScryfallService scryfallService, IDataContext context)
        {
            this.scryfallService = scryfallService;
            this.context = context;
            Cards = new ObservableCollection<Card>();
            Libraries = new ObservableCollection<Library>();
        }


        public async Task LoadTestCard ()
        {
            Cards.Clear ();
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
        }
        public async Task CreateNewLibrary ()
        {
            await context.CreateLibraryAsync(DateTime.Now, "active");
        }
        public async Task LoadLibraries ()
        {
            Libraries.Clear ();
            var l = await context.RetrieveLibrariesAsync();
            foreach (var library in l) 
            {
                Libraries.Add(library);
            }
        }
    }
}
