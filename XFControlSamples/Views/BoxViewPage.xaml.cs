using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxViewPage : ContentPage
    {
        public BoxViewPage()
        {
            InitializeComponent();
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            // 記事ではBoxRendererでPlatform毎に対応が必要とあったけど、Pixel3では意図通りに表示された
            var ratio = 0.9;

            var (boxWidth, boxHeight) = (Width * ratio, Height * ratio);
            boxView.WidthRequest = boxWidth;
            boxView.HeightRequest = boxHeight;

            var message = new[]
            {
                $"PageSize: {Width:f3} x {Height:f3}",
                $"BoxSize: {boxWidth:f2} x {boxHeight:f2}"
            };
            labelSize.Text = string.Join(Environment.NewLine, message);
        }
    }
}