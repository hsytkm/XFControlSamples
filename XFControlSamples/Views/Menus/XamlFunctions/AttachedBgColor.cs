using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace XFControlSamples.Views.Menus
{
    static class AttachedBgColor
    {
        // 添付プロパティ
        // https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/xaml/attached-properties

        public static readonly BindableProperty BgColorProperty =
            BindableProperty.CreateAttached(
                propertyName: "BgColor",
                returnType: typeof(string),
                declaringType: typeof(AttachedBgColor),
                defaultValue: "",
                // 以降はデフォルト引数あり省略可
                defaultBindingMode: BindingMode.OneWay,
                validateValue: IsValidBgColor,
                propertyChanged: OnBgColorPropertyChanged,
                propertyChanging: OnBgColorPropertyChanging,
                coerceValue: CoerceBgColor,
                defaultValueCreator: DefaultBgColorCreator);

        public static string GetBgColor(BindableObject bindable) =>
            (string)bindable.GetValue(BgColorProperty);

        public static void SetBgColor(BindableObject bindable, string value) =>
            bindable.SetValue(BgColorProperty, value);

        // 検証コールバックによって false が返されると、例外が発生します。
        private static bool IsValidBgColor(BindableObject bindable, object value)
        {
            var isValid = (value is string);

            Debug.WriteLine($"{nameof(AttachedBgColor)}_validateValue: {isValid}");
            return isValid;
        }

        private static void OnBgColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is VisualElement visual && newValue is string name)
            {
                visual.BackgroundColor = GetExistColorKeyValue(name).Color;
            }
            Debug.WriteLine($"{nameof(AttachedBgColor)}_propertyChanged: {oldValue} -> {newValue}");
        }

        private static void OnBgColorPropertyChanging(BindableObject bindable, object oldValue, object newValue)
        {
            Debug.WriteLine($"{nameof(AttachedBgColor)}_propertyChanging: {oldValue} -> {newValue}");
        }

        // 値を補正できる ※Coerce=(人に)強制して(力ずくで)～させる
        private static object CoerceBgColor(BindableObject bindable, object value)
        {
            var color = (value is string name)
                ? GetExistColorKeyValue(name) : GetDefaultBgColorKeyValue();

            Debug.WriteLine($"{nameof(AttachedBgColor)}_coerceValue: {value} -> {color}");
            return color.Name;
        }

        // デフォルト値を生成できる
        private static object DefaultBgColorCreator(BindableObject bindable) =>
            GetDefaultBgColorKeyValue().Name;

        private static (string Name, Color Color) GetDefaultBgColorKeyValue() =>
            (nameof(Color.Transparent), Color.Transparent);

        // 引数の名前が存在したらColorを返す(存在しなければデフォ色)
        private static (string Name, Color Color) GetExistColorKeyValue(string name)
        {
            var n = name.ToLower();
            var key = Models.SampleData.XamarinFormsColors
                .FirstOrDefault(x => x.Name.ToLower() == n);

            return (key != default) ? key : GetDefaultBgColorKeyValue();
        }

    }
}
