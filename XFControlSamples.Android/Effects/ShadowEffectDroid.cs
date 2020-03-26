using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("XFControlSamples")]
[assembly: ExportEffect(typeof(XFControlSamples.Droid.Effects.ShadowEffectDroid), nameof(XFControlSamples.Views.Menus.ShadowEffect))]
namespace XFControlSamples.Droid.Effects
{
    class ShadowEffectDroid: PlatformEffect
    {
        float _shadowRadius, _shadowDx, _shadowDy;
        Android.Graphics.Color _shadowColor;

        protected override void OnAttached()
        {
            if (!(Element is Xamarin.Forms.View view)) return;
            if (!(Control is Android.Widget.TextView textView)) return;

            // Cache the previous state.
            _shadowRadius = textView.ShadowRadius;
            _shadowDx = textView.ShadowDx;
            _shadowDy = textView.ShadowDy;
            _shadowColor = textView.ShadowColor;

            var defaultColor = XFControlSamples.Views.Menus.ShadowEffect.GetColor(view).ToAndroid();
            textView.SetShadowLayer(5f, 2f, 2f, defaultColor);
        }

        protected override void OnDetached()
        {
            if (!(Element is Xamarin.Forms.View)) return;
            if (!(Control is Android.Widget.TextView textView)) return;

            textView.SetShadowLayer(_shadowRadius, _shadowDx, _shadowDy, _shadowColor);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            if (!(Element is Xamarin.Forms.View view)) return;
            if (!(Control is Android.Widget.TextView textView)) return;

            if (e.PropertyName == XFControlSamples.Views.Menus.ShadowEffect.ColorProperty.PropertyName)
            {
                var newShadowColor = XFControlSamples.Views.Menus.ShadowEffect.GetColor(view).ToAndroid();
                textView.SetShadowLayer(textView.ShadowRadius, textView.ShadowDx, textView.ShadowDy, newShadowColor);
            }
        }

    }
}