using System;
using Xamarin.Forms;

namespace XFControlSamples.Views.Behaviors
{
    class SearchBarTextChangedCommandBehavior : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += SearchBar_TextChanged;
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            bindable.TextChanged -= SearchBar_TextChanged;

            base.OnDetachingFrom(bindable);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is SearchBar searchBar)) return;
            searchBar.SearchCommand?.Execute(e.NewTextValue);
        }
    }
}
