using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Safety_app.Helpers.Converters
{
    class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
         
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
         
            if (value != null)
            {
                return Int32.Parse(value.ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}
