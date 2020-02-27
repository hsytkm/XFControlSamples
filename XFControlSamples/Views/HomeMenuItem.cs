using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using XFControlSamples.Views.Menus;
using XFControlSamples.Extensions;

namespace XFControlSamples.Views
{
    internal class HomeMenuItem
    {
        // 下記ページを参考に区分
        // https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/user-interface/controls/
        public enum Type
        {
            About,
            //Pages,
            LayoutSingle,
            LayoutMultiple,
            Presentation,
            InitiateCommands,
            SettingValues,
            EditingText,
            IndicateActivity,
            DisplayCollections,
        }

        /// <summary>各メニューに対応するページ辞書</summary>
        public static IDictionary<Type, Page> PagesMap => new Dictionary<Type, Page>()
        {
            [Type.About] = new AboutPage(),
            //Type.Pages] = new Page(),
            [Type.LayoutSingle] = new LayoutSingleMenuPage(),
            [Type.LayoutMultiple] = new LayoutMultipleMenuPage(),
            [Type.Presentation] = new PresentationMenuPage(),
            [Type.InitiateCommands] = new InitiateCommandsMenuPage(),
            [Type.SettingValues] = new SettingValuesMenuPage(),
            [Type.EditingText] = new EditingTextMenuPage(),
            [Type.IndicateActivity] = new IndicateActivityMenuPage(),
            [Type.DisplayCollections] = new DisplayCollectionsMenuPage(),
        };

        public Type Id { get; }

        public string Title { get; }

        public HomeMenuItem(Type id, string title) => (Id, Title) = (id, title);

        public static IList<HomeMenuItem> AllItems =>
            MyArrayExtension.GetEnums<Type>()
                .Select(t => new HomeMenuItem(t, Enum.GetName(typeof(Type), t))).ToList();
    }
}
