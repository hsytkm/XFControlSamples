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
using XFControlSamples.Interfaces;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DependencyPage : ContentPage
    {
        public DependencyPage()
        {
            InitializeComponent();

            BindingContext = new DependencyPageViewModel();
        }
    }

    class DependencyPageViewModel : INotifyPropertyChanged
    {
        public string Os { get; }
        public string Model { get; }

        public int NewInstanceCount
        {
            get => _newInstanceCount;
            private set => SetProperty(ref _newInstanceCount, value);
        }
        private int _newInstanceCount;

        public ICommand IncrementNewInstance => _incrementNewInstance ??
            (_incrementNewInstance = new Command(() =>
            {
                var platform = DependencyService.Get<IPlatformInfo>(DependencyFetchTarget.NewInstance);
                NewInstanceCount = ++platform.Count;
            }));
        private ICommand _incrementNewInstance;

        public int GlobalInstanceCount
        {
            get => _globalInstanceCount;
            private set => SetProperty(ref _globalInstanceCount, value);
        }
        private int _globalInstanceCount;

        public ICommand IncrementGlobalInstance => _incrementGlobalInstance ??
            (_incrementGlobalInstance = new Command(() =>
            {
                var platform = DependencyService.Get<IPlatformInfo>(DependencyFetchTarget.GlobalInstance);
                GlobalInstanceCount = ++platform.Count;
            }));
        private ICommand _incrementGlobalInstance;

        public ICommand ClearCommand => _clearCommand ??
            (_clearCommand = new Command(() => GlobalInstanceCount = NewInstanceCount = 0));
        private ICommand _clearCommand;
        
        public DependencyPageViewModel()
        {
            // デフォルト引数は "GlobalInstance"
            var platform = DependencyService.Get<IPlatformInfo>();

            // インスタンスを取得できない場合はnullになる
            if (platform != null)
            {
                Os = platform.OsVersion;
                Model = platform.GetModel();
            }
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