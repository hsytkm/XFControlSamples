using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadioButtonPage : ContentPage
    {
        public RadioButtonPage()
        {
            InitializeComponent();

            BindingContext = new RadioButtonViewModel();
        }
    }

    class RadioButtonViewModel : INotifyPropertyChanged
    {
        public Color SelectedColor
        {
            get => _selectedColor;
            set => SetProperty(ref _selectedColor, value);
        }
        private Color _selectedColor = Color.Transparent;

        public bool IsColorRed
        {
            get => _isColorRed;
            set
            {
                if (SetProperty(ref _isColorRed, value))
                {
                    if (value) SelectedColor = Color.LightPink;
                }
            }
        }
        private bool _isColorRed;

        public bool IsColorGreen
        {
            get => _isColorGreen;
            set
            {
                if (SetProperty(ref _isColorGreen, value))
                {
                    if (value) SelectedColor = Color.LightGreen;
                }
            }
        }
        private bool _isColorGreen;

        public bool IsColorBlue
        {
            get => _isColorBlue;
            set
            {
                if (SetProperty(ref _isColorBlue, value))
                {
                    if (value) SelectedColor = Color.LightBlue;
                }
            }
        }
        private bool _isColorBlue;

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