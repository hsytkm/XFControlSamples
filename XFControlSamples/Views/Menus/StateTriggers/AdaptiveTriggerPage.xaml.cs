using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdaptiveTriggerPage : ContentPage
    {
        public AdaptiveTriggerPage()
        {
            InitializeComponent();

            // 方向の切り替え画面サイズ閾値
            double widthThresh = (Device.RuntimePlatform == Device.UWP) ? 1000 :  600;

            // 直接バインドすると、DoubleにCastできないと警告出るのでClass用意してみた
            //BindingContext = widthThresh;
            BindingContext = new AdaptiveTriggerViewModel() { WidthThresh = widthThresh };
        }
    }

    class AdaptiveTriggerViewModel
    {
        public double WidthThresh { get; set; }
    }
}
