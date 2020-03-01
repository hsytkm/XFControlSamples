using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class RefreshViewPage : ContentPage
    {
        public RefreshViewPage()
        {
            InitializeComponent();

            BindingContext = new RefreshViewPageViewModel();
        }
    }

    class RefreshViewPageViewModel : INotifyPropertyChanged
    {
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        private bool _isRefreshing;

        public ICommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new Command(async () =>
            {
                await Task.Delay(1000); // HeavyTask

                Items.Add(DateTime.Now);

                // trueで入ってくるのでfalseにする(falseにしないと更新が終わらない)
                IsRefreshing = false;
            }));
        private ICommand _refreshCommand;

        public ObservableCollection<DateTime> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        private ObservableCollection<DateTime> _items = new ObservableCollection<DateTime>()
            {
                new DateTime(1981, 12, 14),
                new DateTime(2020, 3, 1, 9, 53, 21),
            };

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