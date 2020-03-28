using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net.Http;
using System.Web;

namespace AurNet.AurHttpClient
{
    public enum SearchField
    {
        Name,
        NameDesc,
        Maintainer,
        Depends,
        MakeDepends,
        OptDepends,
        CheckDepends,
    }

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

        private readonly SearchField _searchField;
        private readonly string _arg;

        public SearchTypeUrlBuilder(SearchField searchField, string arg)
        {
            _searchField = searchField;
            _arg = arg;
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

    // public class InfoTypeUrlBuilder : ClientUrlBuilder
    // {
    //     private readonly InfoTypeQueryParams _queryParams;

    //     public InfoTypeUrlBuilder(InfoTypeQueryParams queryParams)
    //     {
    //         _queryParams = queryParams;
    //     }

    //     public override string TypeQueryParamValue => "info";

    //     protected override NameValueCollection GetTypeQueryParams()
    //     {

    //     }
    // }

    public abstract class ClientUrlBuilder
    {
        private const string BaseUrl = "https://aur.archlinux.org/rpc/";
        private const int Version = 5;
        private const string TypeQueryParamKey = "type";
        private const string VersionQueryParamKey = "v";

        public abstract string TypeQueryParamValue { get; }

        protected abstract NameValueCollection GetTypeQueryParams();

        public string Build()
        {
            var builder = new UriBuilder(BaseUrl);
            builder.Port = -1;

            var query = this.BuildBaseQueryParams(builder.Query);
            this.SetTypeQueryParams(query);
            builder.Query = query.ToString();

            return builder.ToString();
        }

        private NameValueCollection BuildBaseQueryParams(string query)
        {
            var baseQuery = HttpUtility.ParseQueryString(query);
            baseQuery[VersionQueryParamKey] = Version.ToString();
            baseQuery[TypeQueryParamKey] = TypeQueryParamValue;

            return baseQuery;
        }

        private void SetTypeQueryParams(NameValueCollection query)
        {
            query.Add(this.GetTypeQueryParams());
        }
    }

    public class AurHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();
    }
}