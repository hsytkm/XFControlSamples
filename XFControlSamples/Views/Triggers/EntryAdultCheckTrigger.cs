using System;
using Xamarin.Forms;

namespace XFControlSamples.Views.Triggers
{
    class EntryAdultCheckTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            var adultAge = 20;
            if (int.TryParse(sender.Text, out var value) && value >= adultAge)
            {
                sender.TextColor = Color.Black;
            }
            else
            {
                sender.TextColor = Color.Red;
            }
        }
    }
}