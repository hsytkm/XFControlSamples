using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        // MasterDetailPageのコードは新規プロジェクトのskeltonから取得した

        private readonly IDictionary<HomeMenuItem.PageType, Page> _menuPages =
            new Dictionary<HomeMenuItem.PageType, Page>();

        public MainPage()
        {
            InitializeComponent();

            //_menuPages.Add(HomeMenuUtil.GetTypeFirst(), (NavigationPage)this.Detail);
        }

        internal async Task NavigateFromMenu(HomeMenuItem.PageType pageType)
        {
            // ページが存在しなければ、その都度作成する
            if (!_menuPages.ContainsKey(pageType))
            {
                var type = HomeMenuItem.PagesMap[pageType];
                var page = (Page)Activator.CreateInstance(type);
                _menuPages.Add(pageType, new NavigationPage(page));
            }

            var newPage = _menuPages[pageType];

            if (newPage != null && this.Detail != newPage)
            {
                this.Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}