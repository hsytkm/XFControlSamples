using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;

[assembly: Xamarin.Forms.Dependency(typeof(XFControlSamples.UWP.PlatformInfo))]
namespace XFControlSamples.UWP
{
    // DependencyServiceで使う実装（UWP）
    public class PlatformInfo : XFControlSamples.Interfaces.IPlatformInfo
    {
        public int Count { get; set; }

        private readonly EasClientDeviceInformation _devInfo = new EasClientDeviceInformation();

        public string OsVersion
        {
            get => _devInfo.OperatingSystem;
        }

        public string GetModel()
        {
            return $"{_devInfo.SystemManufacturer} {_devInfo.SystemProductName}";
        }
    }
}
