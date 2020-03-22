using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(XFControlSamples.iOS.PlatformInfo))]
namespace XFControlSamples.iOS
{
    // DependencyServiceで使う実装（iOS） ◆動作未確認
    public class PlatformInfo : XFControlSamples.Interfaces.IPlatformInfo
    {
        public int Count { get; set; }

        public string OsVersion
        {
            get
            {
                var device = UIKit.UIDevice.CurrentDevice;
                return $"{device.SystemName} {device.SystemVersion}";
            }
        }

        public string GetModel()
        {
            return UIKit.UIDevice.CurrentDevice.Model;
        }
    }
}