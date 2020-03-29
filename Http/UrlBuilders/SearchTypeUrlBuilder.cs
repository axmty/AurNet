using System.Collections.Generic;
using System.Collections.Specialized;
using AurNet.Models;

namespace AurNet.Http.UrlBuilders
{
    public class SearchTypeUrlBuilder : ClientUrlBuilder
    {
        private const string SearchFieldQueryParamKey = "by";
        private const string ArgQueryParamKey = "arg";

        private static readonly Dictionary<SearchField, string> SearchFieldNames
            = new Dictionary<SearchField, string>
            {
                [SearchField.CheckDepends] = "checkdepends",
                [SearchField.Depends] = "depends",
                [SearchField.Maintainer] = "maintainer",
                [SearchField.MakeDepends] = "makedepends",
                [SearchField.Name] = "name",
                [SearchField.NameDesc] = "name-desc",
                [SearchField.OptDepends] = "optdepends",
            };

        private readonly string _arg;
        private readonly SearchField _searchField;

        public SearchTypeUrlBuilder(string arg, SearchField searchField)
        {
            _arg = arg;
            _searchField = searchField;
        }

        public override string TypeQueryParamValue => "search";

        protected override NameValueCollection GetTypeQueryParams()
        {
            var query = new NameValueCollection();
            query[SearchFieldQueryParamKey] = SearchFieldNames[_searchField];
            query[ArgQueryParamKey] = _arg;

            return query;
        }
    }
}