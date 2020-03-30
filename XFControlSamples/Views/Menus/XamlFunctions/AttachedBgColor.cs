using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace XFControlSamples.Views.Menus
{
    class AttachedBgColor
    {
        // 添付プロパティ
        // https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/xaml/attached-properties

        // ◆あんまちゃんとした例になってない…
        public static readonly BindableProperty BgColorProperty =
            BindableProperty.CreateAttached(
                propertyName: "BgColor",
                returnType: typeof(Color),
                declaringType: typeof(AttachedPropertyPage),
                defaultValue: Color.Transparent,
                // 以降はデフォルト引数あり省略可
                defaultBindingMode: BindingMode.OneWay,
                validateValue: IsValidBgColor,
                propertyChanged: OnBgColorPropertyChanged,
                propertyChanging: OnBgColorPropertyChanging,
                coerceValue: CoerceBgColor,
                defaultValueCreator: DefaultBgColorCreator);

        public static Color GetBgColor(BindableObject bindable) =>
            (Color)bindable.GetValue(BgColorProperty);

        public static void SetBgColor(BindableObject bindable, Color value) =>
            bindable.SetValue(BgColorProperty, value);

        // 検証コールバックによって false が返されると、例外が発生します。
        private static bool IsValidBgColor(BindableObject bindable, object value)
        {
            var isValid = (value is Color);

            Debug.WriteLine($"{nameof(AttachedBgColor)}_validateValue: {isValid}");
            return isValid;
        }

        private static void OnBgColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is VisualElement visual && newValue is Color newColor)
            {
                visual.BackgroundColor = newColor;
            }
            Debug.WriteLine($"{nameof(AttachedBgColor)}_propertyChanged: {oldValue} -> {newValue}");
        }

        // ◆Changed よりも先に呼ばれるが、どのように使い分けるのか謎…
        private static void OnBgColorPropertyChanging(BindableObject bindable, object oldValue, object newValue)
        {
            Debug.WriteLine($"{nameof(AttachedBgColor)}_propertyChanging: {oldValue} -> {newValue}");
        }

        // 値を補正できる ※Coerce=(人に)強制して(力ずくで)～させる
        private static object CoerceBgColor(BindableObject bindable, object value)
        {
            if (value is Color color)
            {
                if (color == Color.Transparent) color = Color.Red;

                Debug.WriteLine($"{nameof(AttachedBgColor)}_coerceValue: {color}");
                return color;
            }
            return value;
        }

        // デフォルト値を生成できる
        private static object DefaultBgColorCreator(BindableObject bindable)
        {
            var list = Models.SampleData.XamarinFormsColors;
            var index = new Random().Next(0, list.Count());  // maxValueは含まれない
            var color = list[index].Color;

            Debug.WriteLine($"{nameof(AttachedBgColor)}_defaultValueCreator: {color}");
            return color;
        }

    }
}
