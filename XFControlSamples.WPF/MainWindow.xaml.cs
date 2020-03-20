using System;

namespace XFControlSamples.WPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Xamarin.Forms.Platform.WPF.FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();

            // Preview機能を使用するには、Forms.Initを呼び出す前にフラグ設定が必要
            Xamarin.Forms.Forms.SetFlags(
                "SwipeView_Experimental",       // Xamarin.Forms4.4以降(有効にしても動かない。Previewやしね)
                "StateTriggers_Experimental"    // Xamarin.Forms4.5以降
                //"IndicatorView_Experimental",
                //"CarouselView_Experimental",
                //"MediaElement_Experimental"
                );

            Xamarin.Forms.Forms.Init();
            LoadApplication(new XFControlSamples.App());
        }
    }
}
