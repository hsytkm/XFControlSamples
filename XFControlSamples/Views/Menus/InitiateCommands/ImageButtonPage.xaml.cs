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
    public partial class ImageButtonPage : ContentPage
    {
        public ImageButtonPage()
        {
            InitializeComponent();

            BindingContext = new ImageButtonViewModel();
        }
    }

    class ImageButtonViewModel : INotifyPropertyChanged
    {
        private const string _resourceName = "XFControlSamples.Resources.Images.xama_logo_in_shared_project.png";
        public ImageSource ImageResource => ImageSource.FromResource(_resourceName);

        public ICommand ButtonClick => _buttonClick ??
            (_buttonClick = new Command<string>(text => Application.Current.MainPage.DisplayAlert(text, "", "OK")));
        private ICommand _buttonClick;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}