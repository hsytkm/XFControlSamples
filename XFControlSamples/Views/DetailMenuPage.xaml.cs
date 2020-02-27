using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailMenuPage : ContentPage
    {
        private MainPage RootPage => Application.Current.MainPage as MainPage;

        public DetailMenuPage()
        {
            InitializeComponent();

            var menuItems = HomeMenuItem.AllItems;
            listViewMenu.ItemsSource = menuItems;
            listViewMenu.SelectedItem = menuItems[0];

            listViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem is null) return;

                var id = ((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}