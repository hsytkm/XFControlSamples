using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using XFControlSamples.Views.Menus;

namespace XFControlSamples.Views
{
    internal class HomeMenuItem
    {
        // 下記ページを参考に区分
        // https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/user-interface/controls/
        public enum Type
        {
            About,
            Browse,
            //Pages,
            LayoutSingle,
            //Presentation,
            //InitiateCcommands,
            //SettingValues,
            //EditingText,
            //IndicateActivity,
            //DisplayCollections,
        }

        /// <summary>各メニューに対応するページ辞書</summary>
        public static IDictionary<Type, Page> PagesMap => new Dictionary<Type, Page>()
        {
            [Type.About] = new AboutPage(),
            [Type.Browse] = new TextBoxPage(),
            [Type.LayoutSingle] = new LayoutSingleMenuPage(),
        };

        public Type Id { get; }

        public string Title { get; }

        public HomeMenuItem(Type id, string title) => (Id, Title) = (id, title);

        #region static ctor
        public static IList<HomeMenuItem> AllItems { get; }

        static HomeMenuItem()
        {
            var items = new List<HomeMenuItem>();
            foreach (Type type in Enum.GetValues(typeof(Type)))
            {
                items.Add(new HomeMenuItem(type, Enum.GetName(typeof(Type), type)));
            }
            AllItems = items;
        }
        #endregion

    }
}
