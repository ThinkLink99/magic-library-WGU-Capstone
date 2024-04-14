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
    public partial class CardListPage : ContentPage
    {
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
    }
}