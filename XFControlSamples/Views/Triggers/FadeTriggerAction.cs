using Xamarin.Forms;

namespace XFControlSamples.Views.Triggers
{
    class FadeTriggerAction : TriggerAction<VisualElement>
    {
        public int StartsFrom { set; get; }

        protected override void Invoke(VisualElement sender)
        {
            if (sender is null) return;

            sender.Animate(nameof(FadeTriggerAction), new Animation((d) =>
            {
                var val = (StartsFrom == 1) ? d : 1.0 - d;
                sender.BackgroundColor = Color.FromRgb(val, val, val);
            }),
            length: 1000, // milliseconds
            easing: Easing.Linear);
        }
    }
}
