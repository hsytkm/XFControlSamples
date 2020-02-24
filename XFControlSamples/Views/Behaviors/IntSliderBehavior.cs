using System;
using Xamarin.Forms;

namespace XFControlSamples.Views.Behaviors
{
    class IntSliderBehavior : Behavior<Slider>
    {
        public static readonly BindableProperty IntValueProperty = BindableProperty.Create(
            nameof(IntValue),
            typeof(int),
            typeof(IntSliderBehavior),
            default(int),
            BindingMode.OneWayToSource);

        public int IntValue
        {
            get => (int)GetValue(IntValueProperty);
            set => SetValue(IntValueProperty, value);
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            if (!(bindable is Slider slider)) return;
            slider.ValueChanged += Slider_ValueChanged;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);

            if (!(bindable is Slider slider)) return;
            slider.ValueChanged -= Slider_ValueChanged;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            IntValue = (int)e.NewValue;
        }
    }
}
