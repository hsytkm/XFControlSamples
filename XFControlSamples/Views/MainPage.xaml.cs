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

        private readonly IDictionary<HomeMenuItem.Type, Page> _menuPages =
            new Dictionary<HomeMenuItem.Type, Page>();

        public MainPage()
        {
            InitializeComponent();

            //_menuPages.Add(HomeMenuUtil.GetTypeFirst(), (NavigationPage)this.Detail);
        }

        internal async Task NavigateFromMenu(HomeMenuItem.Type id)
        {
            if (!_menuPages.ContainsKey(id))
            {
                _menuPages.Add(id, new NavigationPage(HomeMenuItem.PagesMap[id]));
            }

            var newPage = _menuPages[id];

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