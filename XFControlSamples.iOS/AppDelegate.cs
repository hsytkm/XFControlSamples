﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace XFControlSamples.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Preview機能を使用するには、Forms.Initを呼び出す前にフラグ設定が必要
            global::Xamarin.Forms.Forms.SetFlags(
                //"MediaElement_Experimental",
                "IndicatorView_Experimental",
                "CarouselView_Experimental",
                "StateTriggers_Experimental",   // Xamarin.Forms4.5以降
                "SwipeView_Experimental"        // Xamarin.Forms4.4以降
                );

            global::Xamarin.Forms.Forms.Init();

            App.ScreenSize = (UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
