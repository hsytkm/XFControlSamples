using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardView : ContentView
    {
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            nameof(BorderColor), typeof(Color), typeof(CardView), Color.Gray);
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty CardColorProperty = BindableProperty.Create(
            nameof(CardColor), typeof(Color), typeof(CardView), Color.Black);
        public Color CardColor
        {
            get => (Color)GetValue(CardColorProperty);
            set => SetValue(CardColorProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor), typeof(Color), typeof(CardView), Color.White);
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(
            nameof(CardTitle), typeof(string), typeof(CardView), nameof(CardTitle));
        public string CardTitle
        {
            get => (string)GetValue(CardTitleProperty);
            set => SetValue(CardTitleProperty, value);
        }

        public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(
            nameof(CardDescription), typeof(string), typeof(CardView), nameof(CardDescription));
        public string CardDescription
        {
            get => (string)GetValue(CardDescriptionProperty);
            set => SetValue(CardDescriptionProperty, value);
        }

        public CardView()
        {
            InitializeComponent();
        }
    }
}