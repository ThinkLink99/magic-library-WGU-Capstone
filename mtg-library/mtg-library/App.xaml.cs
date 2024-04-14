using LazyCache;
using Microsoft.Extensions.DependencyInjection;
using mtg_library.Data;
using mtg_library.Services;
using mtg_library.ViewModels;
using System;
using Xamarin.Forms;

namespace mtg_library
{
    public partial class App : Application
    {
        protected static IServiceProvider ServiceProvider { get; set; }
        public App(Action<IServiceCollection> addPlatformServices = null)
        {
            InitializeComponent();
            ConfigureServices(addPlatformServices);
            MainPage = new NavigationPage(new Views.TabbedMainPage());
        }

        void ConfigureServices (Action<IServiceCollection> addPlatformServices = null)
        {
            var services = new ServiceCollection();

            addPlatformServices?.Invoke(services);

            // add viewmodels
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<LibraryPageViewModel>();
            services.AddTransient<LibraryDetailsViewModel>();
            services.AddTransient<CardListPageViewModel>();
            //services.AddTransient<DecksPageViewModel>();

            // Add services
            services.AddSingleton<IDataContext, DataContext>();
            services.AddSingleton<ScryfallService>();

            services.AddLazyCache();

            ServiceProvider = services.BuildServiceProvider ();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static BaseViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel => ServiceProvider.GetService<TViewModel>();
    }
}
