using System.Collections.Generic;
using System.Collections.Specialized;

namespace AurNet.Http.UrlBuilders
{
    public class InfoTypeUrlBuilder : ClientUrlBuilder
    {
        private const string ArgsQueryParamKey = "arg[]";

        private readonly IEnumerable<string> _packages;

        public InfoTypeUrlBuilder(IEnumerable<string> packages)
        {
            _packages = packages;
        }

        public override string TypeQueryParamValue => "info";

        protected override NameValueCollection GetTypeQueryParams()
        {
            var query = new NameValueCollection();
            foreach (var package in _packages)
            {
                query.Add(ArgsQueryParamKey, package);
            }

            return query;
        }
    }
}