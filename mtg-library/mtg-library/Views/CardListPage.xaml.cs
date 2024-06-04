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

        private void btnFilterBlackMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterBlackMana = !ViewModel.FilterBlackMana;
        }
        private void btnFilterBlueMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterBlueMana = !ViewModel.FilterBlueMana;
        }
        private void btnFilterRedMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterRedMana = !ViewModel.FilterRedMana;
        }
        private void btnFilterGreenMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterGreenMana = !ViewModel.FilterGreenMana;
        }
        private void btnFilterWhiteMana_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterWhiteMana = !ViewModel.FilterWhiteMana;
        }

        private void btnStartSearch_Clicked(object sender, EventArgs e)
        {
            ViewModel.FilterCards();
        }

        private async void OnToggleFilterTrayButtonClicked(object sender, EventArgs e)
        {
            if (isFilterTrayVisible)
            {
                // Slide out
                //await Task.WhenAll(
                      //ToggleFilterTrayButton.TranslateTo(0, 0, 250, Easing.SinIn)
                    //);
                await FilterTray.TranslateTo(0, -400, 250, Easing.SinIn);
                FilterTrayRow.Height = new GridLength(0);
                ToggleFilterTrayButton.Text = "Show Filters";
            }
            else
            {
                // Slide in
                //await Task.WhenAll(
                     //ToggleFilterTrayButton.TranslateTo(0, FilterTray.Bounds.Bottom, 250, Easing.SinOut)
                    //);
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

        private void FilterTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.FilterCards();
        }
    }
}