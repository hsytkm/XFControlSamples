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
    public partial class CheckBoxPage : ContentPage
    {
        public CheckBoxPage()
        {
            InitializeComponent();

            BindingContext = new CheckBoxViewModel();
        }
    }

    class CheckBoxViewModel : INotifyPropertyChanged
    {
        public bool IsEnable {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }
        private bool _isEnable;

        public ICommand SwitchIsEnableCommand => _switchIsEnableCommand ??
            (_switchIsEnableCommand = new Command(() => IsEnable = !IsEnable));
        private ICommand _switchIsEnableCommand;

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