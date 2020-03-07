using System;
using Xamarin.Forms;

namespace XFControlSamples.Views.Menus
{
    class ObjectContainerTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }
        public DataTemplate Template3 { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is IObjectContainer data)
            {
                if (data.Data is bool) return Template1;
                if (data.Data is int) return Template2;
                if (data.Data is string) return Template3;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
