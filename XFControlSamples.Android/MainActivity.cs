using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XFControlSamples.Droid
{
    [Activity(Label = "XFControlSamples", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Android戻るボタンの誤操作対応(2回押したら有効にする)
        /// https://www.dylanberry.com/2020/02/20/how-to-confirm-exit-in-android-with-xamarin-forms/
        /// </summary>
        public override void OnBackPressed()
        {
            if (!_isBackPressed)
            {
                _isBackPressed = true;

                using var toast = Toast.MakeText(this, "Press back again to close", ToastLength.Short);
                toast.Show();

                // Disable back to exit after 2 seconds.
                using var handler = new Handler();
                handler.PostDelayed(() => _isBackPressed = false, 2000);
            }
            else
            {
                base.OnBackPressed();
            }
        }
        private bool _isBackPressed;

    }
}