using System;

namespace XFControlSamples.Models
{
    class NameValueKey
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public NameValueKey(string name, string value) =>
            (Name, Value) = (name, value);
    }
}
