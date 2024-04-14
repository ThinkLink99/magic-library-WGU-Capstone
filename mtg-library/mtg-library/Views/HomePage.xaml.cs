using mtg_library.Services;
using mtg_library.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mtg_library.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePageViewModel ViewModel => (HomePageViewModel)BindingContext;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = App.GetViewModel<HomePageViewModel>();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
        }

        
    }
}
