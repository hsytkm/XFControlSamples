using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselViewPage : ContentPage
    {
        public CarouselViewPage()
        {
            InitializeComponent();

            BindingContext = new CarouselViewModel();
        }
    }

    class CarouselViewModel : INotifyPropertyChanged
    {
        public IList<ColorListViewItem> SourceColors { get; } =
            Models.SampleData.XamarinFormsColors.Select(x => new ColorListViewItem(x))
                .Take(5).ToList();

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