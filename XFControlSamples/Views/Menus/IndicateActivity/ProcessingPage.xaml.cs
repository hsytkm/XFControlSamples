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
    public partial class ProcessingPage : ContentPage
    {
        public ProcessingPage()
        {
            InitializeComponent();

            BindingContext = new ProcessingViewModel();
        }
    }

    class ProcessingViewModel : INotifyPropertyChanged
    {
        private const int TimeCounterMax = 6;   // 6秒計測

        public double ProgressRatio
        {
            get => _progressRatio;
            set => SetProperty(ref _progressRatio, value);
        }
        private double _progressRatio;

        public bool IsProcessing
        {
            get => _isProcessing;
            set => SetProperty(ref _isProcessing, value);
        }
        private bool _isProcessing;

        public ICommand StartProcess => _startProcess ??
            (_startProcess = new Command(async () =>
            {
                IsProcessing = true;
                ProgressRatio = 0;

                var sec = 0;
                do
                {
                    await Task.Delay(1000);
                    ProgressRatio = (++sec) / (double)TimeCounterMax;
                }
                while (sec < TimeCounterMax);

                IsProcessing = false;
            }));
        private ICommand _startProcess;


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