using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFControlSamples.Views;

namespace XFControlSamples
{
    public partial class App : Application
    {
        // Panジェスチャで使ってます
        // https://docs.microsoft.com/ja-jp/samples/xamarin/xamarin-forms-samples/workingwithgestures-pangesture/
        public static (double Width, double Height) ScreenSize;

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart() は、アプリケーションの起動時に呼び出されます");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep() は、アプリケーションがバックグラウンドに移行したときに呼び出されます");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume() は、アプリケーションがバックグラウンドから再開したときに呼び出されます");
        }

    }

    // どこに書いたらよいか分からなかったので…
    public static class FormsSetting
    {
        // Preview機能を使用するためには、Forms.Initを呼び出す前にフラグ設定が必要
        private static readonly string[] _setFlags = new[]
        {
            "RadioButton_Experimental",     // Xamarin.Forms4.6以降
            //"MediaElement_Experimental",
            "IndicatorView_Experimental",
            "CarouselView_Experimental",
            "StateTriggers_Experimental",   // Xamarin.Forms4.5以降
            "SwipeView_Experimental"        // Xamarin.Forms4.4以降
        };

        public static string[] GetSetFlags() => _setFlags;
    }
}
