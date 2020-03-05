using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GesturesPage : ContentPage
    {
        public GesturesPage()
        {
            InitializeComponent();

            BindingContext = new GesturesPageViewModel();
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (!(BindingContext is GesturesPageViewModel vm)) return;

            // 無理やりだけどshoganai
            vm.Message = "Pinched";
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (!(BindingContext is GesturesPageViewModel vm)) return;

            // 無理やりだけどshoganai
            vm.Message = "Panned";
        }
    }

    class GesturesPageViewModel : INotifyPropertyChanged
    {
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        private string _message;

        public ICommand UpdateMessageCommand => new Command<string>(msg =>
        {
            Message = msg;
        });

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