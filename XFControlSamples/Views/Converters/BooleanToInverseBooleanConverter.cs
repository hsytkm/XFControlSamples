using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFControlSamples.Views.Converters
{
    class BooleanToInverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b) return !b;
            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b) return !b;
            throw new NotSupportedException();
        }
    }
}
