using Xamarin.Forms;

namespace XFControlSamples.Views.Menus
{
    public class ButtonGradientEffect : RoutingEffect
    {
        public static readonly string Group = "XFControlSamples"; // this.GetType().GetTypeInfo().Assembly.GetName().Name;
        public static readonly string Name = nameof(ButtonGradientEffect);

        public ButtonGradientEffect() : base(Group + "." + Name){ }

        // Attached Property
        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached("Color", typeof(Color), typeof(ShadowEffect), Color.Red);

        public static Color GetColor(View view) =>
            (Color)view.GetValue(ColorProperty);

        public static void SetColor(View view, Color color) =>
            view.SetValue(ColorProperty, color);

    }
}
