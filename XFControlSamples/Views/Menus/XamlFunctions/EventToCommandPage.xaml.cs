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
    public partial class EventToCommandPage : ContentPage
    {
        public EventToCommandPage()
        {
            InitializeComponent();

            BindingContext = new EventToCommandViewModel();
        }
    }

    class EventToCommandViewModel : INotifyPropertyChanged
    {
        public int Counter
        {
            get => _counter;
            private set => SetProperty(ref _counter, value);
        }
        private int _counter;

        public ICommand Add1Command => _add1Command ??
            (_add1Command = new Command(() => Counter++));
        private ICommand _add1Command;

        public ICommand AddXCommand => _addXCommand ??
            (_addXCommand = new Command<int>(prm => Counter += prm));
        private ICommand _addXCommand;

        // Converterを用意せずCastしてもOK
        //public ICommand AddXCommand => _addXCommand ??
        //    (_addXCommand = new Command<object>(prm => Counter += (int)prm));
        //private ICommand _addXCommand;

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