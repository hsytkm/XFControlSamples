using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.MarkupExtensions
{
    [ContentProperty(nameof(Source))]
    class EmbeddedImageResourceExtension : IMarkupExtension<ImageSource>
    {
        public string Source { set; get; }

        public ImageSource ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Source))
            {
                var lineInfo = (serviceProvider.GetService(typeof(IXmlLineInfoProvider)) is IXmlLineInfoProvider lineInfoProvider)
                    ? lineInfoProvider.XmlLineInfo : new XmlLineInfo();

                throw new XamlParseException($"{nameof(EmbeddedImageResourceExtension)} requires {nameof(Source)} property to be set", lineInfo);
            }

            var assemblyName = GetType().GetTypeInfo().Assembly.GetName().Name;
            return ImageSource.FromResource(assemblyName + "." + Source, typeof(EmbeddedImageResourceExtension).GetTypeInfo().Assembly);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) =>
            (this as IMarkupExtension<ImageSource>).ProvideValue(serviceProvider);
    }
}