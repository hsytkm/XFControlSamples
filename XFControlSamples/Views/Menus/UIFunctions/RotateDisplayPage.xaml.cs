using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RotateDisplayPage : ContentPage
    {
        public RotateDisplayPage()
        {
            InitializeComponent();

            SizeChanged += OnSizeChanged;

            BindingContext = new RotateDisplayViewModel();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (!(BindingContext is RotateDisplayViewModel vm)) return;

            if ((vm.PageWidth, vm.PageHeight) != (width, height))
            {
                //ここに画面サイズが割り当てられた場合の処理内容を記載します。
                //Debug.WriteLine($"RotateDisplayPage.OnSizeAllocated(): NewSize=({width}x{height})");
                vm.SetPageSize(width, height);
            }
        }

        protected void OnSizeChanged(object sender, EventArgs e)
        {
            //ここに画面サイズが変更になった場合の処理内容を記載します。
            //Debug.WriteLine("RotateDisplayPage..OnSizeChanged()");
        }
    }

    class RotateDisplayViewModel : INotifyPropertyChanged
    {
        public double PageWidth { get; private set; }
        public double PageHeight { get; private set; }

        public string Message
        {
            get => _message;
            private set => SetProperty(ref _message, value);
        }
        private string _message;

        private readonly List<string> _pageSizeLog = new List<string>();

        public void SetPageSize(double width, double height)
        {
            (PageWidth, PageHeight) = (width, height);
            _pageSizeLog.Add($"{_pageSizeLog.Count} : {width:f2} x {height:f2}");

            int listCount = _pageSizeLog.Count;
            int maxCount = 7;   // 最大行数を指定(Viewから指定すべき…)

            int count = Math.Min(listCount, maxCount);
            int index = Math.Max(0, listCount - maxCount);
            Message = string.Join(Environment.NewLine, _pageSizeLog.GetRange(index, count));
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