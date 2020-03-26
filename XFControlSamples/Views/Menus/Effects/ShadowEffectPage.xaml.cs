using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFControlSamples.Models;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShadowEffectPage : ContentPage
    {
        public ShadowEffectPage()
        {
            InitializeComponent();
        }

        private int _buttonCounter = 0;
        private void Button_Clicked(object sender, EventArgs e)
        {
            // ボタン押下でEffectの色を変えていく
            if (SampleData.XamarinFormsColors.Count() <= ++_buttonCounter)
                _buttonCounter = 0;

            var color = SampleData.XamarinFormsColors[_buttonCounter].Color;

            ShadowEffect.SetColor(_labelShadow, color);
            ButtonGradientEffect.SetColor(_buttonShadow, color);
        }

    }
}