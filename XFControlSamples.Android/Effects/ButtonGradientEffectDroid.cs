using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(XFControlSamples.Droid.Effects.ButtonGradientEffectDroid), nameof(XFControlSamples.Views.Menus.ButtonGradientEffect))]
namespace XFControlSamples.Droid.Effects
{
    class ButtonGradientEffectDroid : PlatformEffect
    {
        private Android.Graphics.Drawables.Drawable _oldDrawable;

        protected override void OnAttached()
        {
            if (!(Element is Xamarin.Forms.Button)) return;

            _oldDrawable = Control.Background;
            SetGradient();
        }

        protected override void OnDetached()
        {
            if (_oldDrawable != default)
            {
                Control.Background = _oldDrawable;
            }
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == XFControlSamples.Views.Menus.ButtonGradientEffect.ColorProperty.PropertyName)
            {
                SetGradient();
            }
        }

        private void SetGradient()
        {
            if (!(Element is Xamarin.Forms.Button xfButton)) return;

            var colorTop = xfButton.BackgroundColor.ToAndroid();
            var colorBottom = XFControlSamples.Views.Menus.ButtonGradientEffect.GetColor(xfButton).ToAndroid();

            var drawable = Gradient.GetGradientDrawable(colorTop, colorBottom);
            Control.SetBackground(drawable);
        }
    }

    static class Gradient
    {
        public static Android.Graphics.Drawables.GradientDrawable GetGradientDrawable(Android.Graphics.Color colorTop, Android.Graphics.Color colorBottom)
        {
            return new Android.Graphics.Drawables.GradientDrawable(
                Android.Graphics.Drawables.GradientDrawable.Orientation.TopBottom,
                new int[] { colorTop, colorBottom });
        }
    }
}