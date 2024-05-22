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

            ViewModel.GetCardDetails(Guid.Parse("56ebc372-aabd-4174-a943-c7bf59e5028d"));
        }
        public CardDetailsPage(Models.Card card)
        {
            InitializeComponent();
			BindingContext = App.GetViewModel<CardDetailsViewModel>();

            ViewModel.Card = card;
        }
    }
}