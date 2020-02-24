using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepeaterViewPage : ContentPage
    {
        public RepeaterViewPage()
        {
            InitializeComponent();

            BindingContext = Models.SampleData.Data;
        }

        private void RepeaterViewItem_Tapped(object sender, EventArgs e)
        {
            if (!(sender is View view)) return;

            var tappedData = view.BindingContext.ToString();
            DisplayAlert($"This is \"{tappedData}\"!", "", "OK");
        }

    }
}