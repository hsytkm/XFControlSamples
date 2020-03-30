using System;
using System.Reflection;
using Xamarin.Forms;

namespace XFControlSamples.Views.Behaviors
{
    /*  再利用可能な EffectBehavior
     *    https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/effect-behavior
     *  
     *  xamlでビヘイビアを使ってEffectを付けるパターン
     *  
     *  ビヘイビアを使うメリットは以下らしい。添付プロパティがないEffectなら良いかも。
     *    『エフェクトの定型コードを分離コード ファイルから削除できることです』
     */
    class EffectBehavior : Behavior<View>
    {
        // Group指定がなければ、AssemblyName になる
        public static readonly BindableProperty GroupProperty =
            BindableProperty.Create(nameof(Group), typeof(string), typeof(EffectBehavior), null);

        // EffectTypeの型名を優先するが、Name指定があれば優先する
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(string), typeof(EffectBehavior), null);

        public static readonly BindableProperty EffectTypeProperty =
            BindableProperty.Create(nameof(EffectType), typeof(Type), typeof(EffectBehavior), null);

        public string Group
        {
            get => (string)GetValue(GroupProperty);
            set => SetValue(GroupProperty, value);
        }

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public Type EffectType
        {
            get => (Type)GetValue(EffectTypeProperty);
            set => SetValue(EffectTypeProperty, value);
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            AddEffect(bindable as View);
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            RemoveEffect(bindable as View);
            base.OnDetachingFrom(bindable);
        }

        private void AddEffect(View view)
        {
            var effect = GetEffect();
            if (effect is null) return;

            view.Effects.Add(effect);
        }

        private void RemoveEffect(View view)
        {
            var effect = GetEffect();
            if (effect is null) return;

            view.Effects.Remove(effect);
        }

        private Effect GetEffect()
        {
            // Group指定がなければ、AssemblyName にしてあげてみる
            var group = Group;
            if (string.IsNullOrWhiteSpace(group))
            {
                Group = group = this.GetType().GetTypeInfo().Assembly.GetName().Name;
            }

            // Effect型名を優先するが、名前指定があれば優先する
            var name = EffectType?.Name;
            if (string.IsNullOrWhiteSpace(name)) name = Name;

            if (string.IsNullOrWhiteSpace(group) || string.IsNullOrWhiteSpace(name))
                return null;

            // 存在しない場合は Xamarin.Forms.NullEffect(internal) が返ってくるっぽい
            return Effect.Resolve(group + "." + name);
        }

    }
}