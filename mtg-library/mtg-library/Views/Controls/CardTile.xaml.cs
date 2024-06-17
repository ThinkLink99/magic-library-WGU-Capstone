using mtg_library.Data;
using mtg_library.Models;
using mtg_library.Services;
using mtg_library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mtg_library.Views.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardTile : ContentView
	{
        private ScryfallService scryfallService;
        private Guid _cardId;
        private LibraryCard _libraryCard;

        public static readonly BindableProperty CardProperty =
            BindableProperty.Create(nameof(Card), typeof(Card), typeof(CardTile), propertyChanged: OnPropertyChanged);

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //((CardTile)bindable).CardId = ((Card)newValue).Id;
        }

        public Card Card
        {
            get => (Card)GetValue(CardProperty);
            set {
                SetValue(CardProperty, value);
            } 
        }
        public Guid CardId
        {
            get => _cardId;
            set
            {
                _cardId = value;
                //_libraryCard = GetLibraryCard().Result;
            }
        }

        public CardTile ()
		{
			InitializeComponent ();
            BindingContext = this;
        }

        //public async Task<LibraryCard> GetLibraryCard ()
        //{
        //    using (var context = new DataContext())
        //    {
        //        Library library = null;
        //        // verify a library is created
        //        // get active library id if one or more exist
        //        if (UserPrefs.Instance.ActiveLibraryId != Guid.Empty)
        //        {
        //            library = await context.RetrieveLibraryAsync(UserPrefs.Instance.ActiveLibraryId.ToString());
        //        }
        //        else
        //        {
        //            // if not, prompt the user that one will be generated automatically
        //            await Application.Current.MainPage.DisplayAlert("No Library Found", "An existing library has not been found, one will be created.", "Ok");

        //            // create library and store id
        //            await context.CreateLibraryAsync(DateTime.Now, "active");
        //            library = (await context.RetrieveLibrariesAsync())[0];
        //            UserPrefs.Instance.ActiveLibraryId = library.Id;
        //        }

        //        // get id of card
        //        var cardId = Card.Id;

        //        // verify that a card exists in the library already
        //        var cardVerify = await context.RetrieveLibraryCardAsync(library.Id.ToString(), cardId.ToString());
        //        if (cardVerify == null)
        //            cardVerify = new LibraryCard() { CardId = cardId, LibraryId = library.Id };

        //        return cardVerify;
        //    }
        //}
        //public async Task UpdateLibraryCard ()
        //{
        //    using (var context = new DataContext())
        //    {
        //        // if not create a new one with the quantity above
        //        if (await context.LibraryCardExists(_libraryCard.LibraryId.ToString(),
        //                                            _libraryCard.CardId.ToString()))
        //            await context.CreateLibraryCardAsync(_libraryCard.LibraryId.ToString(),
        //                                                 _libraryCard.CardId.ToString());
        //        else
        //            await context.UpdateLibraryCardAsync(_libraryCard);
        //    }
        //}

        private async void AddToLibrary_Clicked(object sender, EventArgs e)
        {
            //_libraryCard.Quantity++;
            //QuantityInLibrary.Text = _libraryCard.Quantity.ToString();

            //if (_libraryCard.Quantity > 0)
            //{
            //    QuantityInLibrary.IsVisible = true;
            //    SubtractFromLibrary.IsVisible = true;
            //}

            //await UpdateLibraryCard();
        }
        private async void SubtractFromLibrary_Clicked(object sender, EventArgs e)
        {
            //_libraryCard.Quantity--;
            //QuantityInLibrary.Text = _libraryCard.Quantity.ToString();

            //if (_libraryCard.Quantity == 0)
            //{
            //    QuantityInLibrary.IsVisible = false;
            //    SubtractFromLibrary.IsVisible = false;
            //}

            //await UpdateLibraryCard();
        }
    }
}