using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateTimePickerPage : ContentPage
    {
        public DateTimePickerPage()
        {
            InitializeComponent();

            BindingContext = new CheckBoxViewModel();
        }
    }

}