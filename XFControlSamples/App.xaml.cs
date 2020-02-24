using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFControlSamples.Views;

namespace XFControlSamples
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
