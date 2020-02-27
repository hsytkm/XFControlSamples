using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelPage : ContentPage
    {
        public LabelPage()
        {
            InitializeComponent();

            BindingContext = new LabelViewModel();
        }
    }

    class LabelViewModel
    {
        public string En => "New Corona Virus is prevalent worldwide in 2020. The world is confused. You keep in mind to wash your hands and gargle.";
        public string Jp => "2020年 世界は 新型コロナ Virus で Panic 状態 です。手洗い と うがい を心掛けましょう！";

        //public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public ICommand TapCommand => new Command<string>(async (url) => await Browser.OpenAsync(url));

    }
}