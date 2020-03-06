using System;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindableLayoutPage : ContentPage
    {
        public BindableLayoutPage()
        {
            InitializeComponent();

            BindingContext = Models.SampleData.XamarinFormsColors
                .Select(x => new ColorListViewItem(x)).ToList();
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (!(e is TappedEventArgs args)) return;
            DisplayAlert($"This color is \"{args.Parameter}\"!", "", "OK");
        }
    }
}