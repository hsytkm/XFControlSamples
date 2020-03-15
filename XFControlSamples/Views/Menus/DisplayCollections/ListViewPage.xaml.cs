using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            BindingContext = new ListViewModel();
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
            if (!(e.SelectedItem is ColorListViewItem item)) return;
            DisplayAlert($"This is \"{item.Name}\"!", "", "OK");
        }
    }

    class ListViewModel : INotifyPropertyChanged
    {
        public IList<ColorListViewItem> SourceColors { get; } =
            Models.SampleData.XamarinFormsColors.Select(x => new ColorListViewItem(x)).ToList();

        public ColorListViewItem SelectedColor
        {
            get => _selectedColor;
            set => SetProperty(ref _selectedColor, value);
        }
        private ColorListViewItem _selectedColor;

        public bool IsSelectionSingle
        {
            get => _isSelectionSingle;
            set
            {
                if (SetProperty(ref _isSelectionSingle, value))
                    SelectionMode = value ? ListViewSelectionMode.Single : ListViewSelectionMode.None;
            }
        }
        private bool _isSelectionSingle;

        public ListViewSelectionMode SelectionMode
        {
            get => _selectionMode;
            private set => SetProperty(ref _selectionMode, value);
        }
        private ListViewSelectionMode _selectionMode = ListViewSelectionMode.None;

        public ListViewModel()
        {
            SelectedColor = SourceColors[4];    // Initialize
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}