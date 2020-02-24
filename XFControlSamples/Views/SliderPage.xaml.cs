using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SliderPage : ContentPage
    {
        public SliderPage()
        {
            InitializeComponent();

            BindingContext = new SliderViewModel();
        }
    }

    public class SliderViewModel : INotifyPropertyChanged
    {
        public double SliderMin => -5;
        public double SliderMax => 5;

        public double SliderValue
        {
            get => _sliderValue;
            set => SetProperty(ref _sliderValue, value);
        }
        private double _sliderValue;

        public int SliderIntValue
        {
            get => _sliderIntValue;
            set => SetProperty(ref _sliderIntValue, value);
        }
        private int _sliderIntValue;

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