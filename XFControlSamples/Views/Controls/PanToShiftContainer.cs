using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XFControlSamples.Views.Controls
{
    class PanToShiftContainer : ContentView
	{
		private double _x, _y;

		public PanToShiftContainer()
		{
			// Set PanGestureRecognizer.TouchPoints to control the 
			// number of touch points needed to pan
			var panGesture = new PanGestureRecognizer();
			panGesture.PanUpdated += OnPanUpdated;
			GestureRecognizers.Add(panGesture);
		}

		private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
		{
            var content = Content;
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