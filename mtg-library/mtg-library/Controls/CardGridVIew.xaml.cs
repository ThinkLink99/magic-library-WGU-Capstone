using mtg_library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mtg_library.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardGridView : ContentView, INotifyPropertyChanged
    {
        //private ObservableCollection<Card> cards;
        //public ObservableCollection<Card> Cards
        //{
        //    get => cards;
        //    set
        //    {
        //        cards = value;
        //        OnPropertyChanged(nameof(Cards));
        //    }
        //}
        //public static readonly BindableProperty CardsProperty = BindableProperty.Create(
        //                                               propertyName: "Cards",
        //                                               returnType: typeof(ObservableCollection<Card>),
        //                                               declaringType: typeof(CardGridView),
        //                                               defaultValue: default,
        //                                               defaultBindingMode: BindingMode.OneWay,
        //                                               propertyChanged: CardsPropertyChanged);

        //private static void CardsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    var control = bindable as CardGridView;
        //    control.Cards = newValue as ObservableCollection<Card>;
        //}

        public CardGridView()
        {
            InitializeComponent();
        }
    }
}