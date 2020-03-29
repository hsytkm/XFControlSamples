using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XFControlSamples.Views.Behaviors
{
    // 下記ページのBehavior移植
    // https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/app-fundamentals/gestures/pinch
    class PinchToZoomBehavior : Behavior<ContentView>
    {
        private PinchGestureRecognizer _pinchGesture;
        private double _currentScale = 1;
        private double _startScale = 1;
        private double _xOffset = 0;
        private double _yOffset = 0;

        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);

            _pinchGesture = new PinchGestureRecognizer();
            _pinchGesture.PinchUpdated += OnPinchUpdated;
            bindable.GestureRecognizers.Add(_pinchGesture);
        }

        protected override void OnDetachingFrom(ContentView bindable)
        {
            if (_pinchGesture != null)
            {
                bindable.GestureRecognizers.Remove(_pinchGesture);
                _pinchGesture.PinchUpdated -= OnPinchUpdated;
                _pinchGesture = null;
            }

            base.OnDetachingFrom(bindable);
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (!(sender is ContentView parent)) return;
            var content = parent.Content;

            switch (e.Status)
            {
                case GestureStatus.Started:
                    // Store the current scale factor applied to the wrapped user interface element,
                    // and zero the components for the center point of the translate transform.
                    _startScale = content.Scale;
                    content.AnchorX = 0;
                    content.AnchorY = 0;
                    break;
                case GestureStatus.Running:
                    // Calculate the scale factor to be applied.
                    _currentScale += (e.Scale - 1) * _startScale;
                    _currentScale = Math.Max(1, _currentScale);

                    // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                    // so get the X pixel coordinate.
                    double renderedX = content.X + _xOffset;
                    double deltaX = renderedX / parent.Width;
                    double deltaWidth = parent.Width / (content.Width * _startScale);
                    double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                    // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                    // so get the Y pixel coordinate.
                    double renderedY = content.Y + _yOffset;
                    double deltaY = renderedY / parent.Height;
                    double deltaHeight = parent.Height / (content.Height * _startScale);
                    double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                    // Calculate the transformed element pixel coordinates.
                    double targetX = _xOffset - (originX * content.Width) * (_currentScale - _startScale);
                    double targetY = _yOffset - (originY * content.Height) * (_currentScale - _startScale);

                    // Apply translation based on the change in origin.
                    content.TranslationX = targetX.Clamp(-content.Width * (_currentScale - 1), 0);
                    content.TranslationY = targetY.Clamp(-content.Height * (_currentScale - 1), 0);

                    // Apply scale factor.
                    content.Scale = _currentScale;
                    break;
                case GestureStatus.Completed:
                    // Store the translation delta's of the wrapped user interface element.
                    _xOffset = content.TranslationX;
                    _yOffset = content.TranslationY;
                    break;
            }
        }
    }
}
