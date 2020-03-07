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

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScrollViewPage : ContentPage
    {
        public ScrollViewPage()
        {
            InitializeComponent();

            BindingContext = new ScrollViewModel();
        }

        private void ScrollViewL_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (!(sender is ScrollView scrollView)) return;

            var x = scrollView.ScrollX;
            var y = scrollView.ScrollY;
            var animated = ((ScrollViewModel)BindingContext).ScrollAnimated;
            ScrollViewR.ScrollToAsync(x, y, animated);
        }

        //private void ScrollViewR_Scrolled(object sender, ScrolledEventArgs e)
        //{
        //    if (!(sender is ScrollView scrollView)) return;

        //    var x = scrollView.ScrollX;
        //    var y = scrollView.ScrollY;
        //    ScrollViewL.ScrollToAsync(x, y, true);
        //}
    }

    class ScrollViewModel : INotifyPropertyChanged
    {
        public IList<string> Items => Enumerable.Range(1, 100).Select(x => "Data " + x).ToList();

        // スクロールのアニメーションフラグ
        public bool ScrollAnimated
        {
            get => _scrollAnimated;
            set => SetProperty(ref _scrollAnimated, value);
        }
        private bool _scrollAnimated = true;

        // ScrollYはTwoWayBindできないのでReadOnly(OneWayToSource)
        public double ScrollOffsetY
        {
            get => _scrollOffsetY;
            set => SetProperty(ref _scrollOffsetY, value);
        }
        private double _scrollOffsetY;

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