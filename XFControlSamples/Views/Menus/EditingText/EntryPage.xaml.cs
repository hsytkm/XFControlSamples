﻿using System;
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
    public partial class EntryPage : ContentPage
    {
        public EntryPage()
        {
            InitializeComponent();

            BindingContext = new EntryViewModel();
        }
    }

    class EntryViewModel : INotifyPropertyChanged
    {
        public string CharText
        {
            get => _charText;
            set => SetProperty(ref _charText, value);
        }
        private string _charText;

        public string NumericText
        {
            get => _numericText;
            set => SetProperty(ref _numericText, value);
        }
        private string _numericText;

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