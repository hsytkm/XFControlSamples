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
    public partial class BoxViewPage : ContentPage
    {
        public BoxViewPage()
        {
            InitializeComponent();
            BindingContext = new BoxViewViewModel();
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            // 記事ではBoxRendererでPlatform毎に対応が必要とあったけど、Pixel3では意図通りに表示された
            var ratio = 0.9;
            var boxWidth = Width * ratio;
            boxView.WidthRequest = boxWidth;

            var message = new[]
            {
                $"BoxView resize automatically",
                $"  WidthRatio: {ratio:P}",
                $"  PageWidth: {Width:f3}",
                $"  BoxWidth: {boxWidth:f2}"
            };
            labelSize.Text = string.Join(Environment.NewLine, message);
        }
    }

    class BoxViewViewModel : INotifyPropertyChanged
    {
        public double SizeSliderMin => 0;
        public double SizeSliderMax => 200;

        public double SizeSliderValue
        {
            get => _sizeSliderValue;
            set
            {
                if (SetProperty(ref _sizeSliderValue, value))
                {
                    SizeMessage = "BoxView.Size : " + value.ToString("f2");
                }
            }
        }
        private double _sizeSliderValue;

        public double RadiusSliderMin => 0;
        public double RadiusSliderMax => 200;

        public double RadiusSliderValue
        {
            get => _radiusSliderValue;
            set
            {
                if (SetProperty(ref _radiusSliderValue, value))
                {
                    // ホントはConverter作った方が良いけどサンプルなのでね～
                    BoxCornerRadius = new CornerRadius(value);
                    RadiusMessage = "BoxView.CornerRadius : " + value.ToString("f2");
                }
            }
        }
        private double _radiusSliderValue;

        public CornerRadius BoxCornerRadius
        {
            get => _boxCornerRadius;
            set => SetProperty(ref _boxCornerRadius, value);
        }
        private CornerRadius _boxCornerRadius;

        public string SizeMessage
        {
            get => _sizeMessage;
            private set => SetProperty(ref _sizeMessage, value);
        }
        private string _sizeMessage;

        public string RadiusMessage
        {
            get => _radiusMessage;
            private set => SetProperty(ref _radiusMessage, value);
        }
        private string _radiusMessage;

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