using System;
using Xamarin.Forms;

// 再利用可能な EventToCommandBehavior
// https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/event-to-command-behavior
namespace XFControlSamples.Views.Behaviors
{
    class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(T bindable)
        {
            bindable.BindingContextChanged -= OnBindingContextChanged;

            AssociatedObject = null;
            base.OnDetachingFrom(bindable);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}

