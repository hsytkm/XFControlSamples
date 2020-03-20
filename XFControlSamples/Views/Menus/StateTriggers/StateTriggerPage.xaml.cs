using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StateTriggerPage : ContentPage
    {
        public StateTriggerPage()
        {
            InitializeComponent();

            BindingContext = new StateTriggerViewModel();
        }

        // VisualState の変更が発生するたびに、VisualState の IsActiveChanged イベントが発生します。
        // 各VisualState によって、このイベントに対するイベントハンドラーが登録されます。
        void OnCheckedStateIsActiveChanged(object sender, EventArgs e)
        {
            if (sender is StateTriggerBase stateTrigger)
            {
                if (BindingContext is StateTriggerViewModel vm)
                {
                    vm.SetMessage($"Checked state active: {stateTrigger.IsActive}");
                }
            }
        }

        void OnUncheckedStateIsActiveChanged(object sender, EventArgs e)
        {
            if (sender is StateTriggerBase stateTrigger)
            {
                if (BindingContext is StateTriggerViewModel vm)
                {
                    vm.SetMessage($"Unchecked state active: {stateTrigger.IsActive}");
                }
            }
        }
    }

    class StateTriggerViewModel : INotifyPropertyChanged
    {
        public bool IsToggled
        {
            get => _isToggled;
            set => SetProperty(ref _isToggled, value);
        }
        private bool _isToggled;

        public string Message
        {
            get => _message;
            private set => SetProperty(ref _message, value);
        }
        private string _message;

        public ICommand ClearMessage => _clearMessage ??
            (_clearMessage = new Command(() => SetMessage(null)));
        private ICommand _clearMessage;

        private readonly StringBuilder _messageBuilder = new StringBuilder();

        public void SetMessage(string msg)
        {
            if (msg is null)
            {
                _messageBuilder.Clear();
            }
            else
            {
                _messageBuilder.AppendLine(msg);
            }
            Message = _messageBuilder.ToString();
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
