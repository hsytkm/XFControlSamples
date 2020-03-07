using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepeaterViewPage : ContentPage
    {
        public RepeaterViewPage()
        {
            InitializeComponent();

            BindingContext = Models.SampleData.XamarinFormsColors
                .Select(x => new ColorListViewItem(x)).ToList();
        }

        private void RepeaterViewItem_Tapped(object sender, EventArgs e)
        {
            if (!(sender is View view)) return;
            if (!(view.BindingContext is ColorListViewItem item)) return;

            DisplayAlert($"This is \"{item.Name}\"!", "", "OK");
        }
    }

}