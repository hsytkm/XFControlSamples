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
    public partial class MessagingCenterPage : ContentPage
    {
        public readonly static string DisplayAlertMessage = nameof(DisplayAlertMessage);
        public readonly static string GoNextMessage = nameof(GoNextMessage);

        private readonly int _pageDepth;

        private MessagingCenterPage(int depth)
        {
            InitializeComponent();

            _pageDepth = depth;
            label.Text = $"Depth={_pageDepth}";

            // 要素数の最大値チェックは未実装
            this.BackgroundColor = Models.SampleData.XamarinFormsColors[_pageDepth].Color;

            BindingContext = new MessagingCenterViewModel();
        }

        public MessagingCenterPage() : this(0) { }

        // Appearing: 画面がアクティブになった際のイベント
        private void MessagingCenterPage_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<MessagingCenterViewModel, AlertParameter>(
                this, DisplayAlertMessage, DisplayAlert);

            MessagingCenter.Subscribe<MessagingCenterViewModel>(
                this, GoNextMessage, GoNextPage);
        }

        // Disappearing: 画面が閉じられたり別の画面が上に表示された際のイベント
        private void MessagingCenterPage_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<MessagingCenterViewModel, AlertParameter>(
                this, DisplayAlertMessage);

            MessagingCenter.Unsubscribe<MessagingCenterViewModel>(
                this, GoNextMessage);
        }

        private async void DisplayAlert<T>(T sender, AlertParameter arg)
        {
            // DisplayAlert は非同期メソッドですが、
            // MessagingCenter.Send が同期メソッドであるために結果を待つことができません。
            // そこで、AlertParameter の Action プロパティでコールバックを設定しています。
            var isAccept = await DisplayAlert(arg.Title, arg.Message, arg.Accept, arg.Cancel);
            arg.Action?.Invoke(isAccept);
        }

        private void GoNextPage<T>(T sender)
        {
            var nextPageDepth = _pageDepth + 1;
            var view = new MessagingCenterPage(nextPageDepth);
            this.Navigation.PushAsync(view);
        }
    }

    class AlertParameter
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Accept { get; set; }
        public string Cancel { get; set; }
        public Action<bool> Action { get; set; }
    }

    class MessagingCenterViewModel : INotifyPropertyChanged
    {
        public ICommand MovePageCommand => _movePageCommand ??
            (_movePageCommand = new Command<ColorListViewItem>(selectedItem =>
            {
                MessagingCenter.Send(this, MessagingCenterPage.DisplayAlertMessage,
                    new AlertParameter()
                    {
                        Title = "確認",
                        Message = "次画面に移動します。よろしいですか？",
                        Accept = "移動する",
                        Cancel = "移動しない",
                        Action = result =>
                        {
                            if (result)
                                MessagingCenter.Send(this, MessagingCenterPage.GoNextMessage);
                        }
                    });
            }));
        private ICommand _movePageCommand;

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