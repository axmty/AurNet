using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Web;

namespace AurNet.AurHttpClient
{
    public class SearchTypeUrlBuilder : ClientUrlBuilder
    {
        public override string TypeQueryParamValue => "search";
    }

    public class InfoTypeUrlBuilder : ClientUrlBuilder
    {
        public override string TypeQueryParamValue => "info";
    }

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

            var query = HttpUtility.ParseQueryString(builder.Query);
            query[VersionQueryParamKey] = Version.ToString();
            query[TypeQueryParamKey] = TypeQueryParamValue;
            builder.Query = query.ToString();

            return builder.ToString();
        }
    }
}

namespace AurNet.AurHttpClient
{
    public class AurHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();
    }
}