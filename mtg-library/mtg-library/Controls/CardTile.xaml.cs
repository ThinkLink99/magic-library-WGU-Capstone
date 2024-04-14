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
	public partial class CardTile : ContentView
	{
		public CardTile ()
		{
			InitializeComponent ();
		}
	}
}