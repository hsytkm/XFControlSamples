using System;
using System.Collections.Generic;
using System.Linq;

namespace XFControlSamples.Models
{
    static class SampleData
    {
        public static IList<string> Data => Enumerable.Range(1, 20).Select(x => "Data " + x).ToList();

    }
}
