using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            BindingContext = Models.SampleData.Data;
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
            DisplayAlert($"This is \"{e.SelectedItem.ToString()}\"!", "", "OK");
        }

    }
}