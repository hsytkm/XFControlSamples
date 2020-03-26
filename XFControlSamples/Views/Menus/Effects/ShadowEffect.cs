using Xamarin.Forms;

namespace XFControlSamples.Views.Menus
{
    public class ShadowEffect : RoutingEffect
    {
        public ShadowEffect()
            : base("XFControlSamples." + nameof(ShadowEffect))
        { }

        // Attached Property
        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached("Color", typeof(Color), typeof(ShadowEffect), Color.DarkGray);

        public static Color GetColor(View view) =>
            (Color)view.GetValue(ColorProperty);

        public static void SetColor(View view, Color color) =>
            view.SetValue(ColorProperty, color);

    }
}
