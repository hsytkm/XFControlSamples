using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemTemplateSelectorPage : ContentPage
    {
        public ItemTemplateSelectorPage()
        {
            InitializeComponent();

            var containers = new List<IObjectContainer>()
            {
                new ObjectContainer<bool>(false),
                new ObjectContainer<bool>(true),
                new ObjectContainer<int>(123),
                new ObjectContainer<string>("Hello"),
                new ObjectContainer<string>(""),
                new ObjectContainer<int>(4321),
                new ObjectContainer<string>("こんにちわ"),
                new ObjectContainer<bool>(false),
                new ObjectContainer<int>(0),
            };
            BindingContext = containers;
        }
    }
}