using System;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            BindingContext = Models.SampleData.XamarinFormsColors
                .Select(x => new ColorListViewItem(x)).ToList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            mainListView.ItemSelected += ListView_ItemSelected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            mainListView.ItemSelected -= ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is ColorListViewItem item)) return;
            DisplayAlert($"This is \"{item.Name}\"!", "", "OK");
        }
    }

    class ColorListViewItem
    {
        public string Name { get; }
        public Color Color { get; }
        public string ColorLevel => $"R={To8bit(Color.R)}, G={To8bit(Color.G)}, B={To8bit(Color.B)}";

        private static int To8bit(double d) => (int)Math.Round(d * 255);

        public ColorListViewItem((string Name, Color Color) x) =>
            (Name, Color) = (x.Name, x.Color);
    }
}