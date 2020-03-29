using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UIFunctionsMenuPage : TabbedPage
    {
        public UIFunctionsMenuPage()
        {
            InitializeComponent();

            // TabbedPage のスワイプ禁止(xaml側で指定しているので無効化)
            // https://stackoverflow.com/questions/45820704/xamarin-forms-disable-swipe-between-pages-in-tabbedpage
            //this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
    }
}