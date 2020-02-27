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
    public partial class FramePage : ContentPage
    {
        public ICommand ButtonClick => _buttonClick ?? (_buttonClick = new Command(() =>
            DisplayAlert("Button is Clicked!", "", "OK")));
        private ICommand _buttonClick;

        public FramePage()
        {
            InitializeComponent();

            BindingContext = ButtonClick;
        }
    }
}