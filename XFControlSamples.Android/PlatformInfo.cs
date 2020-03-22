using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(XFControlSamples.Droid.PlatformInfo))]
namespace XFControlSamples.Droid
{
    // DependencyServiceで使う実装（Android）
    public class PlatformInfo : XFControlSamples.Interfaces.IPlatformInfo
    {
        public int Count { get; set; }

        public string OsVersion { get; } = "Android " + Android.OS.Build.VERSION.Release;

        public string GetModel()
        {
            string manufacturer = Android.OS.Build.Manufacturer;
            string model = Android.OS.Build.Model;
            return $"{manufacturer} {model}";
        }
    }
}
