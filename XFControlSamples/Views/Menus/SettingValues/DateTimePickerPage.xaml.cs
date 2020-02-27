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

            BindingContext = new DateTimePickerViewModel();
        }
    }

    class DateTimePickerViewModel : INotifyPropertyChanged
    {
        public DateTime UserDate
        {
            get => _userDate;
            set => SetProperty(ref _userDate, value);
        }
        private DateTime _userDate = new DateTime(1981, 12, 14);

        public TimeSpan UserTime
        {
            get => _userTime;
            set => SetProperty(ref _userTime, value);
        }
        private TimeSpan _userTime = new TimeSpan(12, 34, 56);

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