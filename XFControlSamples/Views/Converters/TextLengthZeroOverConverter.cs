using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFControlSamples.Views.Converters
{
    class TextLengthZeroOverConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}