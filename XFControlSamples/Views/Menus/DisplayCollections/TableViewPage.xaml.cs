using System;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableViewPage : ContentPage
    {
        public TableViewPage()
        {
            InitializeComponent();
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (!(sender is SwitchCell cell)) return;
            cell.Text = $"Value is {e.Value}.";
        }

        private void VisibleSwitchViewCell_Tapped(object sender, EventArgs e)
        {
            VisibleSwitchLabel.IsVisible = !VisibleSwitchLabel.IsVisible;
            VisibleSwitchViewCell.ForceUpdateSize();
        }

    }
}