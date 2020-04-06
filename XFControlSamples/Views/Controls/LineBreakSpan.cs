using System;
using Xamarin.Forms;

namespace XFControlSamples.Views.Controls
{
    class LineBreakSpan : Span
    {
        public LineBreakSpan()
        {
            Text = Environment.NewLine;
        }
    }
}
