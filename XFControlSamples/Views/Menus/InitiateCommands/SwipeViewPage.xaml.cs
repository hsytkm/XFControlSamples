using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class SwipeViewPage : ContentPage
    {
        public SwipeViewPage()
        {
            InitializeComponent();

            BindingContext = new SwipeViewModel();
        }
    }

    class SwipeViewModel : INotifyPropertyChanged
    {
        public string Message
        {
            get => _message;
            private set => SetProperty(ref _message, value);
        }
        private string _message;

        public ICommand PushCommand => _pushCommand ??
            (_pushCommand = new Command<string>(param => Message = "Pushed " + param));
        private ICommand _pushCommand;

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