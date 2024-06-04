using mtg_library.Data;
using mtg_library.Models;
using mtg_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mtg_library.ViewModels
{
    public class CardListPageViewModel : BaseViewModel
    {
        private readonly ScryfallService scryfallService;
        private readonly IDataContext context;

        private bool filterBlackMana = false;
        private bool filterBlueMana = false;
        private bool filterRedMana = false;
        private bool filterGreenMana = false;
        private bool filterWhiteMana = false;
        private string cardText;
        private ObservableCollection<Card> cards;

        public string CardText
        {
            get => cardText;
            set
            {
                cardText = value;
                OnPropertyChanged(nameof(CardText));
            }
        }

        public bool FilterBlackMana
        {
            get => filterBlackMana;
            set
            {
                filterBlackMana = value;
                OnPropertyChanged(nameof(FilterBlackMana));
            }
        }
        public bool FilterBlueMana
        {
            get => filterBlueMana;
            set
            {
                filterBlueMana = value;
                OnPropertyChanged(nameof(FilterBlueMana));
            }
        }
        public bool FilterRedMana
        {
            get => filterRedMana;
            set
            {
                filterRedMana = value;
                OnPropertyChanged(nameof(FilterRedMana));
            }
        }
        public bool FilterGreenMana
        {
            get => filterGreenMana;
            set
            {
                filterGreenMana = value;
                OnPropertyChanged(nameof(FilterGreenMana));
            }
        }
        public bool FilterWhiteMana
        {
            get => filterWhiteMana;
            set
            {
                filterWhiteMana = value;
                OnPropertyChanged(nameof(FilterWhiteMana));
            }
        }

        public ObservableCollection<Card> Cards 
        { 
            get => cards;
            set
            {
                cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }

        public CardListPageViewModel(ScryfallService scryfallService, IDataContext context)
        {
            this.scryfallService = scryfallService;
            this.context = context;

            Cards = new ObservableCollection<Card>();
        }

        public async Task FilterCards ()
        {
            Cards.Clear();
            var cards = await scryfallService.SearchCards(CardText, new bool[] { FilterBlackMana, FilterBlueMana, FilterRedMana, FilterGreenMana, FilterWhiteMana });
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }

        public ICommand FilterCommand =>
        new Command(async () => {
           await DelayedQueryForKeyboardTypingSearches().ConfigureAwait(false);
        });
        private CancellationTokenSource throttleCts = new CancellationTokenSource();
        /// <summary>
        /// Runs in a background thread, checks for new Query and runs current one
        /// </summary>
        private async Task DelayedQueryForKeyboardTypingSearches()
        {
            try
            {
                Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel();
                await Task.Delay(TimeSpan.FromMilliseconds(500), this.throttleCts.Token)
              .ContinueWith(async task => await FilterCards(),
                            CancellationToken.None,
                            TaskContinuationOptions.OnlyOnRanToCompletion,
                            TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch
            {
                //Ignore any Threading errors
            }
        }
    }
}