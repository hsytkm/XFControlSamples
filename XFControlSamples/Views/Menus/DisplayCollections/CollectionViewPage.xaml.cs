using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionViewPage : ContentPage
    {
        public CollectionViewPage()
        {
            InitializeComponent();

            BindingContext = new CollectionViewModel();
        }
    }

    class CollectionViewModel : INotifyPropertyChanged
    {
        public IList<ColorListViewItem> ColorsSource { get; } =
            Models.SampleData.XamarinFormsColors.Select(x => new ColorListViewItem(x)).ToList();

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        private string _message;

        public bool IsSelectionMulti
        {
            get => _isSelectionMulti;
            set
            {
                if (SetProperty(ref _isSelectionMulti, value))
                    SelectionMode = value ? SelectionMode.Multiple : SelectionMode.Single;
            }
        }
        private bool _isSelectionMulti;

        public SelectionMode SelectionMode
        {
            get => _selectionMode;
            set => SetProperty(ref _selectionMode, value);
        }
        private SelectionMode _selectionMode = SelectionMode.Single;

        public ICommand SelectionChangedCommand => _selectionChangedCommand ??
            (_selectionChangedCommand = new Command<ColorListViewItem>(selectedItem =>
            {
                // パラメータの SelectedItem は、SelectionMode.Single 時のみ更新される
                // (なので、SelectionMode.Multi で選択が変化した時は Single 時に選んだ項目が繰り返し通知される)
                if (SelectionMode == SelectionMode.Single)
                {
                    Message = selectedItem?.Name;
                }
            }));
        private ICommand _selectionChangedCommand;

        // CollectionView doesn't call set. As you click items it modifies the collection that's bound to the SelectedItems property.
        public ObservableCollection<object> NotifySelectedColors { get; } = new ObservableCollection<object>();

        // 選択中のアイテムリスト
        private readonly IList<ColorListViewItem> SelectingColors = new List<ColorListViewItem>();

        public CollectionViewModel()
        {
            NotifySelectedColors.CollectionChanged += SelectedColors_CollectionChanged;
        }

        private void SelectedColors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Android：アイテム選択したら、選択アイテムが Add で通知される
            // UWP：アイテム選択したら、まず Reset が来て、全選択アイテムが Add で通知される
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (ColorListViewItem item in e.NewItems)
                    {
                        SelectingColors.Add(item);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (ColorListViewItem item in e.OldItems)
                    {
                        if (SelectingColors.Contains(item))
                            SelectingColors.Remove(item);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    SelectingColors.Clear();
                    break;
                default:
                    Debug.Assert(true, e.Action.ToString());
                    break;
            }
            Message = string.Join(", ", SelectingColors.Select(x => x.Name));
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
