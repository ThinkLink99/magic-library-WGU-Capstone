using mtg_library.Models;
using mtg_library.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mtg_library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryPage : ContentPage
    {
        public LibraryPageViewModel ViewModel => (LibraryPageViewModel)BindingContext;
        public LibraryPage()
        {
            InitializeComponent();

            BindingContext = App.GetViewModel<LibraryPageViewModel>();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var library = (Library)e.Item;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            await Navigation.PushAsync(new LibraryDetailsPage(library.Id), true);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void btnCreateNewLibrary_Clicked(object sender, EventArgs e)
        {
            await ViewModel.CreateNewLibrary();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await ViewModel.LoadLibraries();
        }
    }
}
