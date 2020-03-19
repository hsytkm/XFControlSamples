using Xamarin.Forms;

namespace XFControlSamples.Views.Triggers
{
    // https://kamusoft.hatenablog.jp/entry/2019/12/01/161823
    class MoveTriggerAction : TriggerAction<VisualElement>
    {
        public bool IsActive { get; set; }

        protected override void Invoke(VisualElement sender)
        {
            if (sender is null) return;

            if (IsActive)
            {
                sender.TranslationX = -sender.Width;
                sender.Opacity = 0;

                sender.TranslateTo(0, 0);
                sender.FadeTo(1);
            }
            else
            {
                sender.TranslateTo(sender.Width, 0);
                sender.FadeTo(0);
            }
        }
    }

}
