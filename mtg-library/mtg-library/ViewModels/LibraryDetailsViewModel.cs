using LazyCache;
using mtg_library.Data;
using mtg_library.Models;
using mtg_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mtg_library.ViewModels
{
    public class LibraryDetailsViewModel : BaseViewModel
    {
        const int DEBOUNCE_TIME = 1000;
        bool _timerStarted = false;

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
        public Library Library 
        { 
            get => _library;
            set {
                _library = value;
                OnPropertyChanged();
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
            Library = await context.RetrieveLibraryAsync(id.ToString());
        }
        public void UpdateLibrary ()
        {
            if (_timerStarted) return;

            _timerStarted = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(DEBOUNCE_TIME), () =>
            {
                context.UpdateLibraryAsync(_library);

                _timerStarted = false;
                return _timerStarted;
            });
        }
        public async Task GetLibraryCards ()
        {
            libraryCards = await context.RetrieveLibraryCardsAsync(Library.Id.ToString());
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
