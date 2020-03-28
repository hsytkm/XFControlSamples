using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

// 再利用可能な EventToCommandBehavior
// https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/event-to-command-behavior
namespace XFControlSamples.Views.Behaviors
{
    class EventToCommandBehavior : BehaviorBase<View>
    {
        private Delegate _eventHandler;

        public static readonly BindableProperty EventNameProperty =
            BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior), null,
                propertyChanged: OnEventNameChanged);

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior), null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(EventToCommandBehavior), null);

        public static readonly BindableProperty InputConverterProperty =
            BindableProperty.Create(nameof(Converter), typeof(IValueConverter), typeof(EventToCommandBehavior), null);

        public string EventName
        {
            get => (string)GetValue(EventNameProperty);
            set => SetValue(EventNameProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public IValueConverter Converter
        {
            get => (IValueConverter)GetValue(InputConverterProperty);
            set => SetValue(InputConverterProperty, value);
        }

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            RegisterEvent(EventName);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            DeregisterEvent(EventName);
            base.OnDetachingFrom(bindable);
        }

        private void RegisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;

            var eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
            if (eventInfo is null)
            {
                throw new ArgumentException($"{nameof(EventToCommandBehavior)}: Can't register the '{EventName}' event.");
            }
            var methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod(nameof(OnEvent));
            _eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(AssociatedObject, _eventHandler);
        }

        private void DeregisterEvent(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            if (_eventHandler is null) return;

            var eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
            if (eventInfo is null)
            {
                throw new ArgumentException($"{nameof(EventToCommandBehavior)}: Can't register the '{EventName}' event.");
            }
            eventInfo.RemoveEventHandler(AssociatedObject, _eventHandler);
            _eventHandler = null;
        }

        private void OnEvent(object sender, object eventArgs)
        {
            if (Command is null) return;

            object resolvedParameter;
            if (CommandParameter != null)
            {
                //resolvedParameter = CommandParameter;

                // CmdParamにもConverterを適用できるように変更した
                resolvedParameter = (Converter != null)
                    ? Converter.Convert(CommandParameter, typeof(object), null, null)
                    : CommandParameter;
            }
            else if (Converter != null)
            {
                resolvedParameter = Converter.Convert(eventArgs, typeof(object), null, null);
            }
            else
            {
                resolvedParameter = eventArgs;
            }

            if (Command.CanExecute(resolvedParameter))
            {
                Command.Execute(resolvedParameter);
            }
        }

        private static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (EventToCommandBehavior)bindable;
            if (behavior?.AssociatedObject is null) return;

            var oldEventName = (string)oldValue;
            var newEventName = (string)newValue;

            behavior.DeregisterEvent(oldEventName);
            behavior.RegisterEvent(newEventName);
        }
    }
}
