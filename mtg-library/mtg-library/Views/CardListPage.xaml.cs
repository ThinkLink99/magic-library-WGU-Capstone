using mtg_library.Models;
using mtg_library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mtg_library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardListPage : ContentPage
    {
        private bool isFilterTrayVisible = false;

        CardListPageViewModel ViewModel => BindingContext as CardListPageViewModel;

        public CardListPage()
        {
            InitializeComponent();
            BindingContext = App.GetViewModel<CardListPageViewModel>();
        }

        private async void btnFilterBlackMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterBlackMana = !ViewModel.FilterBlackMana;
            await ViewModel.FilterCards();
        }
        private async void btnFilterBlueMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterBlueMana = !ViewModel.FilterBlueMana;
            await ViewModel.FilterCards();
        }
        private async void btnFilterRedMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterRedMana = !ViewModel.FilterRedMana;
            await ViewModel.FilterCards();
        }
        private async void btnFilterGreenMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterGreenMana = !ViewModel.FilterGreenMana;
            await ViewModel.FilterCards();
        }
        private async void btnFilterWhiteMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterWhiteMana = !ViewModel.FilterWhiteMana;
            await ViewModel.FilterCards();
        }

        private async void OnToggleFilterTrayButtonClicked(object sender, EventArgs e)
        {
            if (isFilterTrayVisible)
            {
                await FilterTray.TranslateTo(0, -400, 250, Easing.SinIn);
                FilterTrayRow.Height = new GridLength(0);
                ToggleFilterTrayButton.Text = "Show Filters";
            }
            else
            {
                FilterTrayRow.Height = GridLength.Auto;
                await FilterTray.TranslateTo(0, 0, 250, Easing.SinOut);
                ToggleFilterTrayButton.Text = "Hide Filters";
            }

            isFilterTrayVisible = !isFilterTrayVisible;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            FilterTrayRow.Height = new GridLength(0);
        }

        private async void FilterTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await ViewModel.FilterCards();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0) { return; }

            var card = e.CurrentSelection[0] as Card;
            ((CollectionView)sender).SelectedItem = null;

            await Navigation.PushAsync(new CardDetailsPage(card));
        }
    }
}