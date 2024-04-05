using mtg_library.Models;
using mtg_library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace mtg_library.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly ScryfallService scryfallService;
        private ObservableCollection<Card> cards;

        public ObservableCollection<Card> Cards 
        { 
            get => cards; 
            set {
                cards = value;
                OnPropertyChanged(nameof(Cards));
            } 
        }
        public MainPageViewModel(ScryfallService scryfallService)
        {
            this.scryfallService = scryfallService;

            Cards = new ObservableCollection<Card>();
        }


        public async Task LoadTestCard ()
        {
            Cards.Clear ();
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
            Cards.Add(await scryfallService.GetCard("56ebc372-aabd-4174-a943-c7bf59e5028d"));
        }
    }
}
