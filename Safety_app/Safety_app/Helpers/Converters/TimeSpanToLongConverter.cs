﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace Safety_app.Helpers.Converters
{
    public class TimeSpanToLongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new TimeSpan(long.Parse(value.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimeSpan)value).Ticks;
        }
    }
}
