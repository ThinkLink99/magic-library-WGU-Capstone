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
        private LibraryCard _libraryCard;
        private Card _card;
        private readonly ScryfallService scryfallService;
        private readonly IDataContext context;

        public Card Card
        {
            get => _card;
            set {
                _card = value;
                OnPropertyChanged();
            }
        }
        public LibraryCard LibraryCard
        {
            get => _libraryCard;
            set
            {
                _libraryCard = value;
                OnPropertyChanged();
            }
        }
        public string[] CardColors
        {
            get => new string[] { "W", "G", "R", "U", "B" };
        }

        public CardDetailsViewModel(ScryfallService scryfallService, IDataContext context)
        {
            this.scryfallService = scryfallService;
            this.context = context;
        }

        public async Task GetCardDetails(Guid id)
        {
            Card = await scryfallService.GetCard(id.ToString());
        }
        public async Task GetLibraryCard ()
        {
            LibraryCard = await context.RetrieveLibraryCardAsync(UserPrefs.Instance.ActiveLibraryId.ToString(), Card.Id.ToString());
            if (LibraryCard == null)
            {
                LibraryCard = new LibraryCard();
                LibraryCard.LibraryId = UserPrefs.Instance.ActiveLibraryId;
                LibraryCard.CardId = Card.Id;
                LibraryCard.Quantity = 0;
            }
        }

        public void IncreaseQuantity ()
        {
            LibraryCard.Quantity++;
            OnPropertyChanged(nameof(LibraryCard));
        }
        public void DecreaseQuantity()
        {
            LibraryCard.Quantity--;
            OnPropertyChanged(nameof(LibraryCard));
        }
        public async Task UpdateLibraryCard ()
        {
            bool exists = await context.LibraryCardExists(UserPrefs.Instance.ActiveLibraryId.ToString(), Card.Id.ToString());
            if (exists)
            {
                await context.UpdateLibraryCardAsync(LibraryCard);
            }
            else
            {
                await context.CreateLibraryCardAsync(LibraryCard.LibraryId.ToString(),
                                                     LibraryCard.CardId.ToString(),
                                                     LibraryCard.Quantity);
            }
        }
    }
}
