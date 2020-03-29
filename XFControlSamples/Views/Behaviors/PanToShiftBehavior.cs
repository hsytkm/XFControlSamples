using System;
using Xamarin.Forms;

namespace XFControlSamples.Views.Behaviors
{
    // 下記ページのBehavior移植
    // https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/app-fundamentals/gestures/pan
    // https://docs.microsoft.com/ja-jp/samples/xamarin/xamarin-forms-samples/workingwithgestures-pangesture/
    // https://github.com/xamarin/xamarin-forms-samples/tree/master/WorkingWithGestures/PanGesture
    class PanToShiftBehavior : Behavior<ContentView>
    {
        private PanGestureRecognizer _panGesture;
        private double _x = 0;
        private double _y = 0;

        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);

            _panGesture = new PanGestureRecognizer();
            _panGesture.PanUpdated += OnPanUpdated;
            bindable.GestureRecognizers.Add(_panGesture);
        }

        protected override void OnDetachingFrom(ContentView bindable)
        {
            if (_panGesture != null)
            {
                bindable.GestureRecognizers.Remove(_panGesture);
                _panGesture.PanUpdated -= OnPanUpdated;
                _panGesture = null;
            }

            base.OnDetachingFrom(bindable);
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (!(sender is ContentView parent)) return;
            var content = parent.Content;

            var screenSize = App.ScreenSize;
            if (screenSize == (0, 0)) return;   // UWPのサイズ取得してない(可変ウィンドウの扱い分からん…)

            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                    content.TranslationX =
                        Math.Max(Math.Min(0, _x + e.TotalX), -Math.Abs(content.Width - screenSize.Width));
                    content.TranslationY =
                        Math.Max(Math.Min(0, _y + e.TotalY), -Math.Abs(content.Height - screenSize.Height));
                    break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    _x = content.TranslationX;
                    _y = content.TranslationY;
                    break;
            }
        }
    }
}
