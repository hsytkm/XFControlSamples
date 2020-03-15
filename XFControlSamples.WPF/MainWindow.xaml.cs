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

            // Xamarin.Forms4.4以降で SwipeView を使用するため、Forms.Initを呼び出す前に設定が必要
            Xamarin.Forms.Forms.SetFlags("SwipeView_Experimental"); // 有効にしても動かない。Previewやしね。

            Xamarin.Forms.Forms.Init();
            LoadApplication(new XFControlSamples.App());
        }
    }
}
