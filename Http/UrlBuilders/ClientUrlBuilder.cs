using System;
using System.Collections.Specialized;
using System.Web;

namespace AurNet.Http.UrlBuilders
{
    public abstract class ClientUrlBuilder
    {
        private const string BaseUrl = "https://aur.archlinux.org/rpc/";
        private const int Version = 5;
        private const string TypeQueryParamKey = "type";
        private const string VersionQueryParamKey = "v";

        protected abstract string TypeQueryParamValue { get; }

        protected abstract NameValueCollection GetTypeQueryParams();

        public string Build()
        {
            var builder = new UriBuilder(BaseUrl)
            {
                Port = -1
            };

            var query = this.BuildBaseQueryParams(builder.Query);
            this.SetTypeQueryParams(query);
            builder.Query = query.ToString();

            return builder.ToString();
        }

        private NameValueCollection BuildBaseQueryParams(string query)
        {
            var baseQuery = HttpUtility.ParseQueryString(query);
            baseQuery[VersionQueryParamKey] = Version.ToString();
            baseQuery[TypeQueryParamKey] = this.TypeQueryParamValue;

            return baseQuery;
        }

        private void SetTypeQueryParams(NameValueCollection query)
        {
            query.Add(this.GetTypeQueryParams());
        }
    }
}
