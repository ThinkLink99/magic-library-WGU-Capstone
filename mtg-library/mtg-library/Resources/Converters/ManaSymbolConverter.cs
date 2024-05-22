using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace mtg_library.Resources.Converters
{
    public class ManaSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string manaCode)
            {
                string imagePath = $"{manaCode}.svg"; // Assuming your image files are named mana_w.png, mana_u.png, etc.
                return ImageSource.FromFile(imagePath);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
