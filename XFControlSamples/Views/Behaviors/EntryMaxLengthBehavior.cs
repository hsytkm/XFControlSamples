using System;
using System.Linq;
using Xamarin.Forms;

namespace XFControlSamples.Views.Behaviors
{
    // https://rksoftware.wordpress.com/2016/06/12/001-12/
    class EntryMaxLengthBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(
            nameof(MaxLength),
            typeof(int),
            typeof(EntryMaxLengthBehavior),
            int.MaxValue,
            BindingMode.OneWay);

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += Entry_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= Entry_TextChanged;

            base.OnDetachingFrom(bindable);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is Entry entry)) return;
            
            if (e.NewTextValue?.Length <= MaxLength) return;

            // 文字数を越えたら変更前に戻す
            string oldText;
            if (e.OldTextValue?.Length <= MaxLength)
            {
                oldText = e.OldTextValue;
            }
            else
            {
                oldText = new string((e.OldTextValue ?? "").ToCharArray()
                    .Take(MaxLength).ToArray());
            }
            entry.Text = oldText;
        }

    }
}
