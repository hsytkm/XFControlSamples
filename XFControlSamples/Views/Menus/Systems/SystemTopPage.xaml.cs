using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using XFControlSamples.Models;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SystemTopPage : ContentPage
    {
        public SystemTopPage()
        {
            InitializeComponent();

            BindingContext = new SystemTopViewModel();
        }
    }

    class SystemTopViewModel
    {
        public IList<NameValueKey> Items { get; }

        public SystemTopViewModel()
        {
            // PCL  https://www.atmarkit.co.jp/ait/articles/1610/12/news021.html

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                case Device.iOS:
                case Device.UWP:
                case Device.WPF:
                    break;
            }

            Items = new List<NameValueKey>()
            {
                new NameValueKey(nameof(Device.RuntimePlatform), Device.RuntimePlatform),
                new NameValueKey(nameof(Device.Idiom), Device.Idiom.ToString()),
                new NameValueKey(nameof(Device.Info.PixelScreenSize), Device.Info.PixelScreenSize.ToString()),
                new NameValueKey(nameof(Device.Info.ScaledScreenSize), Device.Info.ScaledScreenSize.ToString()),
                new NameValueKey(nameof(Device.Info.CurrentOrientation), Device.Info.CurrentOrientation.ToString()),
            };

        }
    }
}