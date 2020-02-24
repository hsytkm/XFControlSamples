using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace XFControlSamples.Models
{
    static class SampleData
    {
        public static IList<string> Data =>
            Enumerable.Range(1, 20).Select(x => "Data " + x).ToList();

        /// <summary>
        /// Xamarin.Forms.Colorの色リスト
        /// </summary>
        public static IList<(string Name, Color Color)> Colors =>
            typeof(Color).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(x => x.FieldType == typeof(Color))
                .Select(x => (x.Name, (Color)x.GetValue(null)))
                .ToList();

    }
}
