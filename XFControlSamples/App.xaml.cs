﻿using System;
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
}
