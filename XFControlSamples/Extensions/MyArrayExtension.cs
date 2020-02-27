using System;
using System.Collections.Generic;

namespace XFControlSamples.Extensions
{
    static class MyArrayExtension
    {
        public static IEnumerable<T> GetEnums<T>() where T : Enum
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                yield return value;
            }
        }
    }
}
