using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFControlSamples.Views.Controls
{
    class HyperlinkSpan : Span
    {
        public static readonly BindableProperty UrlProperty =
            BindableProperty.Create(nameof(Url), typeof(string), typeof(HyperlinkSpan),
                propertyChanged: OnUrlPropertyChanged);

        public string Url
        {
            get => (string)GetValue(UrlProperty);
            set => SetValue(UrlProperty, value);
        }
        private static void OnUrlPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(newValue is string url)) return;
            if (bindable is Span span)
            {
                if (string.IsNullOrEmpty(span.Text))
                    span.Text = url;
            }
        }

        public HyperlinkSpan()
        {
            TextDecorations = TextDecorations.Underline;
            TextColor = Color.Blue;
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                // Launcher.OpenAsync is provided by Xamarin.Essentials.
                Command = new Command(async () => await Launcher.OpenAsync(Url))
            });
        }
    }
}
