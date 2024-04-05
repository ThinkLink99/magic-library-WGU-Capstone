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
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel => (MainPageViewModel)BindingContext;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.GetViewModel<MainPageViewModel>();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await ViewModel.LoadTestCard();
        }
    }
}
