using mtg_library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mtg_library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardDetailsPage : ContentPage
    {
        public CardDetailsViewModel ViewModel => (CardDetailsViewModel)BindingContext;
        public CardDetailsPage()
        {
            InitializeComponent();
            BindingContext = App.GetViewModel<CardDetailsViewModel>();
        }
        public CardDetailsPage(Models.Card card)
        {
            InitializeComponent();
			BindingContext = App.GetViewModel<CardDetailsViewModel>();

            ViewModel.Card = card;
        }

        private async void SubtractFromLibrary_Clicked(object sender, EventArgs e)
        {
            ViewModel.DecreaseQuantity();
            await ViewModel.UpdateLibraryCard();
        }

        private async void AddToLibrary_Clicked(object sender, EventArgs e)
        {
            ViewModel.IncreaseQuantity();
            await ViewModel.UpdateLibraryCard();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await ViewModel.GetLibraryCard();
        }
    }
}