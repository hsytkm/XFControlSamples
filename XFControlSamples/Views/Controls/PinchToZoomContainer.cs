using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XFControlSamples.Views.Controls
{
    // PinchToZoom コンテナーの作成
    //  https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/app-fundamentals/gestures/pinch
    class PinchToZoomContainer : ContentView
    {
        private double currentScale = 1;
        private double startScale = 1;
        private double xOffset = 0;
        private double yOffset = 0;

        public PinchToZoomContainer()
        {
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            GestureRecognizers.Add(pinchGesture);
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            var content = Content;

            switch (e.Status)
            {
                case GestureStatus.Started:
                    // Store the current scale factor applied to the wrapped user interface element,
                    // and zero the components for the center point of the translate transform.
                    startScale = content.Scale;
                    content.AnchorX = 0;
                    content.AnchorY = 0;
                    break;
                case GestureStatus.Running:
                    // Calculate the scale factor to be applied.
                    currentScale += (e.Scale - 1) * startScale;
                    currentScale = Math.Max(1, currentScale);

                    // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                    // so get the X pixel coordinate.
                    double renderedX = content.X + xOffset;
                    double deltaX = renderedX / this.Width;
                    double deltaWidth = this.Width / (content.Width * startScale);
                    double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                    // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                    // so get the Y pixel coordinate.
                    double renderedY = content.Y + yOffset;
                    double deltaY = renderedY / this.Height;
                    double deltaHeight = this.Height / (content.Height * startScale);
                    double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                    // Calculate the transformed element pixel coordinates.
                    double targetX = xOffset - (originX * content.Width) * (currentScale - startScale);
                    double targetY = yOffset - (originY * content.Height) * (currentScale - startScale);

                    // Apply translation based on the change in origin.
                    content.TranslationX = targetX.Clamp(-content.Width * (currentScale - 1), 0);
                    content.TranslationY = targetY.Clamp(-content.Height * (currentScale - 1), 0);

                    // Apply scale factor.
                    content.Scale = currentScale;
                    break;
                case GestureStatus.Completed:
                    // Store the translation delta's of the wrapped user interface element.
                    xOffset = content.TranslationX;
                    yOffset = content.TranslationY;
                    break;
            }
        }
    }
}
