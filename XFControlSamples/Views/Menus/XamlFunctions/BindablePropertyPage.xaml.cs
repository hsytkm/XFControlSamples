using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindablePropertyPage : ContentPage
    {
        private const int MinAge = 0;
        private const int MaxAge = 128;

        // Xamarin.Formsのバインド可能なプロパティ
        // https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/xaml/bindable-properties

        public static readonly BindableProperty AgeProperty =
            BindableProperty.Create(
                propertyName: nameof(Age),
                returnType: typeof(string),
                declaringType: typeof(BindablePropertyPage),
                // 以降はデフォルト引数あり省略可
                defaultValue: default(string),
                defaultBindingMode: BindingMode.OneWay,
                validateValue: IsValidAge,
                propertyChanged: OnAgePropertyChanged,
                propertyChanging: OnAgePropertyChanging,
                coerceValue: CoerceAge,
                defaultValueCreator: DefaultAgeCreator);

        public string Age
        {
            get => (string)GetValue(AgeProperty);
            set
            {
                try { SetValue(AgeProperty, value); }
                catch (Exception ex) { this.AppendLog(ex.GetType().ToString()); }
            }
        }

        // 検証コールバックによって false が返されると、例外が発生します。
        private static bool IsValidAge(BindableObject bindable, object value)
        {
            var isValid = false;

            // 空ならログをクリア
            if ((value is string s) && string.IsNullOrEmpty(s))
            {
                ((BindablePropertyPage)bindable).ClearLog();
                return isValid;
            }

            // 年齢が負数はあり得ない
            if (int.TryParse(value.ToString(), out var age))
                isValid = (0 <= age);

            ((BindablePropertyPage)bindable).AppendLog($"validateValue: {isValid}");
            return isValid;
        }

        private static void OnAgePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!int.TryParse(oldValue.ToString(), out var oldAge)) return;
            if (!int.TryParse(newValue.ToString(), out var newAge)) return;

            ((BindablePropertyPage)bindable).AppendLog($"propertyChanged: {oldAge} -> {newAge}");
        }

        // ◆Changed よりも先に呼ばれるが、どのように使い分けるのか謎…
        private static void OnAgePropertyChanging(BindableObject bindable, object oldValue, object newValue)
        {
            if (!int.TryParse(oldValue.ToString(), out var oldAge)) return;
            if (!int.TryParse(newValue.ToString(), out var newAge)) return;

            ((BindablePropertyPage)bindable).AppendLog($"propertyChanging: {oldAge} -> {newAge}");
        }

        // 値を補正できる ※Coerce=(人に)強制して(力ずくで)～させる
        private static object CoerceAge(BindableObject bindable, object value)
        {
            if (int.TryParse(value.ToString(), out var oldAge))
            {
                var newAge = oldAge.Clamp(MinAge, MaxAge);

                ((BindablePropertyPage)bindable).AppendLog($"coerceValue: {oldAge} -> {newAge}");
                return newAge.ToString();
            }
            return value;
        }

        // デフォルト値を生成できる
        private static string DefaultAgeCreator(BindableObject bindable)
        {
            var age = new Random().Next(MinAge, 1000);  // maxValueは含まれない

            ((BindablePropertyPage)bindable).AppendLog($"defaultValueCreator: {age}");
            return age.ToString();
        }

        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public BindablePropertyPage()
        {
            InitializeComponent();
        }

        private void AppendLog(string message)
        {
            _stringBuilder.AppendLine(message);
            BindingContext = _stringBuilder.ToString();
        }

        private void ClearLog()
        {
            _stringBuilder.Clear();
            BindingContext = _stringBuilder.ToString();
        }

    }
}