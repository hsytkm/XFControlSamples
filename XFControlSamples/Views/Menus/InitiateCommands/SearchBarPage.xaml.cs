using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBarPage : ContentPage
    {
        public SearchBarPage()
        {
            InitializeComponent();

            BindingContext = new SearchBarViewModel();
        }
    }

    class SearchBarViewModel : INotifyPropertyChanged
    {
        private static readonly IList<ColorListViewItem> _sourceColors =
            Models.SampleData.XamarinFormsColors .Select(x => new ColorListViewItem(x)).ToList();

        public IList<ColorListViewItem> Colors
        {
            get => _colors;
            private set => SetProperty(ref _colors, value);
        }
        private IList<ColorListViewItem> _colors = _sourceColors;

        public ICommand PerformSearch => new Command<string>(query => Colors = GetSearchResults(query));

        private static IList<ColorListViewItem> GetSearchResults(string query)
        {
            var normalizedQuery = query?.Trim().ToLower() ?? "";
            if (string.IsNullOrEmpty(normalizedQuery)) return _sourceColors;

            return _sourceColors.Where(x => x.Name.ToLower().Contains(normalizedQuery)).ToList();
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