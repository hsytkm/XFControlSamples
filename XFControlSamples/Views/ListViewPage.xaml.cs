﻿using System;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            BindingContext = Models.SampleData.Colors
                .Select(x => new ListViewItem(x)).ToList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            mainListView.ItemSelected += ListView_ItemSelected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            mainListView.ItemSelected -= ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DisplayAlert($"This is \"{e.SelectedItem.ToString()}\"!", "", "OK");
        }

    }

    public class ListViewItem
    {
        public string Name { get; }
        public Color Color { get; }

        public ListViewItem((string Name, Color Color) x) =>
            (Name, Color) = (x.Name, x.Color);
    }
}