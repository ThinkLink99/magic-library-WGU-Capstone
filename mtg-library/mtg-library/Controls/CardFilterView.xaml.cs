using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mtg_library.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardFilterView : ContentView
    {
        public string CardText { get; set; }

        public bool FilterBlackMana { get; set; } = false;
        public bool FilterBlueMana { get; set; } = false;
        public bool FilterRedMana { get; set; } = false;
        public bool FilterGreenMana { get; set; } = false;
        public bool FilterWhiteMana { get; set; } = false;


        public CardFilterView()
        {
            InitializeComponent();
        }

        private void btnFilterBlackMana_Clicked(object sender, EventArgs e)
        {
            FilterBlackMana = !FilterBlackMana;
        }
        private void btnFilterBlueMana_Clicked(object sender, EventArgs e)
        {
            FilterBlueMana = !FilterBlueMana;
        }
        private void btnFilterRedMana_Clicked(object sender, EventArgs e)
        {
            FilterRedMana = !FilterRedMana;
        }
        private void btnFilterGreenMana_Clicked(object sender, EventArgs e)
        {
            FilterGreenMana = !FilterGreenMana;
        }
        private void btnFilterWhiteMana_Clicked(object sender, EventArgs e)
        {
            FilterWhiteMana = !FilterWhiteMana;
        }
    }
}