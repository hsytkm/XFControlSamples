﻿using System;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // PF固有のグローバル アクティビティ インジケーターでビジー状態が表示される
            // らしいが、Android(Pixel3) / UWP では何も起きなかった…
            this.IsBusy = true;
            await Task.Delay(3000);
            this.IsBusy = false;
        }
    }

    class ProcessingViewModel : INotifyPropertyChanged
    {
        private const int TimeCounterMax = 6;   // 6秒計測

        public double ProgressRatio
        {
            get => _progressRatio;
            private set => SetProperty(ref _progressRatio, value);
        }
        private double _progressRatio;

        public bool IsProcessing
        {
            get => _isProcessing;
            private set => SetProperty(ref _isProcessing, value);
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