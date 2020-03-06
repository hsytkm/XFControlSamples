using System;
using Xamarin.Forms;

namespace XFControlSamples.Views.Menus
{
    class ColorListViewItem
    {
        public string Name { get; }
        public Color Color { get; }
        public string ColorLevel => $"R={To8bit(Color.R)}, G={To8bit(Color.G)}, B={To8bit(Color.B)}";

        private static int To8bit(double d) => (int)Math.Round(d * 255);

        public ColorListViewItem((string Name, Color Color) x) =>
            (Name, Color) = (x.Name, x.Color);
    }
}
