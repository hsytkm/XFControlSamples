using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFControlSamples.Views.Converters
{
    class ObjectToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Int32 i32) return i32;
            if (value is Int16 i16) return (int)i16;
            if (value is UInt16 ui16) return (int)ui16;
            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}