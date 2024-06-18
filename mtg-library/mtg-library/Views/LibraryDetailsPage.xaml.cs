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
	public partial class LibraryDetailsPage : ContentPage
	{
        public LibraryDetailsViewModel ViewModel => (LibraryDetailsViewModel)BindingContext;
		public LibraryDetailsPage (Guid id)
        {
			InitializeComponent ();
			BindingContext = App.GetViewModel<LibraryDetailsViewModel>();

			ViewModel.GetLibraryDetails(id);
		}

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
			await ViewModel.GetLibraryCards();
        }

        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.UpdateLibrary();
        }
    }
}