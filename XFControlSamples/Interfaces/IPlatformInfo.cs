using System;

namespace XFControlSamples.Interfaces
{
    // DependencyService
    // https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/app-fundamentals/dependency-service/
    // https://www.atmarkit.co.jp/ait/articles/1610/12/news021.html
    public interface IPlatformInfo
    {
        string GetModel();

        string OsVersion { get; }

        int Count { get; set; }
    }
}
