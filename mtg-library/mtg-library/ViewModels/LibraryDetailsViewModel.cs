using LazyCache;
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
    public class LibraryDetailsViewModel : BaseViewModel
    {
        private Library _library;
        private readonly ScryfallService scryfallService;
        private readonly IDataContext context;
        private ObservableCollection<Card> cards;
        private List<LibraryCard> libraryCards;

        public ObservableCollection<Card> Cards
        {
            get => cards;
            set
            {
                cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }

        public LibraryDetailsViewModel(ScryfallService scryfallService, IDataContext context)
        {
            this.scryfallService = scryfallService;
            this.context = context;
            Cards = new ObservableCollection<Card>();
        }
        public async Task GetLibraryDetails(Guid id)
        {
            _library = await context.RetrieveLibraryAsync(id.ToString());
        }
        public async Task GetLibraryCards ()
        {
            libraryCards = await context.RetrieveLibraryCardsAsync(_library.Id.ToString());
            Cards.Clear();
            foreach (var card in libraryCards)
            {
                Cards.Add(await scryfallService.GetCard(card.CardId.ToString()));
            }
        }
        public async Task LoadTestCard()
        {
            Cards.Clear();
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
        }
    }
}
