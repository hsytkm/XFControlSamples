using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFControlSamples.Views.Converters
{
    class BooleanToObjectConverter<T> : IValueConverter
    {
        public T TrueObject { set; get; }

        public T FalseObject { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (value is bool b && b) ? TrueObject : FalseObject;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            ((T)value).Equals(TrueObject);
    }
}
