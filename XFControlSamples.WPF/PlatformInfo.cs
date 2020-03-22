using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(XFControlSamples.WPF.PlatformInfo))]
namespace XFControlSamples.WPF
{
    // DependencyServiceで使う実装（UWP）
    public class PlatformInfo : XFControlSamples.Interfaces.IPlatformInfo
    {
        public int Count { get; set; }

        public string OsVersion
        {
            get => System.Environment.OSVersion.ToString();
        }

        public string GetModel()
        {
            return "機種名の取得方法が分からない(調べてない)";
        }
    }
}
