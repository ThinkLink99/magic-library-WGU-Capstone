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
    public class CardDetailsViewModel : BaseViewModel
    {
        private Card _card;
        private readonly ScryfallService scryfallService;
        private readonly IDataContext context;

        public Card Card
        {
            get => _card;
            set {
                _card = value;
                OnPropertyChanged(nameof(Card));
                OnPropertyChanged(nameof(CardColors));
            }
        }

        public string[] CardColors
        {
            get => new string[] { "W", "G", "R", "U", "B" };
        }

        //public CardDetailsViewModel() { }
        public CardDetailsViewModel(ScryfallService scryfallService, IDataContext context)
        {
            this.scryfallService = scryfallService;
            this.context = context;
        }
        public async Task GetCardDetails(Guid id)
        {
            Card = await scryfallService.GetCard(id.ToString());
        }
    }
}
