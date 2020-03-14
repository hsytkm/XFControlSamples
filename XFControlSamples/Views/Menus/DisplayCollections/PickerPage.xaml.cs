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
    public partial class PickerPage : ContentPage
    {
        public PickerPage()
        {
            InitializeComponent();

            BindingContext = new PickerViewModel();
        }
    }

    class PickerViewModel : INotifyPropertyChanged
    {
        public IList<string> ItemsSource { get; } =
            Models.SampleData.XamarinFormsColors.Select(x => x.Name).ToList();

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value))
                    SelectedColor = Models.SampleData.XamarinFormsColors.First(x => x.Name == value).Color;
            }
        }
        private string _selectedItem;

        public Color SelectedColor
        {
            get => _selectedColor;
            set => SetProperty(ref _selectedColor, value);
        }
        private Color _selectedColor;

        public PickerViewModel()
        {
            SelectedItem = Models.SampleData.XamarinFormsColors.First().Name;
        }

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