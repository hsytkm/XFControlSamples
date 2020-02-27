using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonPage : ContentPage
    {
        public ICommand ButtonClick => _buttonClick ??
            (_buttonClick = new Command<string>(t => DisplayAlert("Text is " + t, "", "OK")));
        private ICommand _buttonClick;

        public ButtonPage()
        {
            InitializeComponent();

            BindingContext = ButtonClick;
        }
    }

}