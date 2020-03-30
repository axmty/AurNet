using System.Collections.Generic;
using System.Collections.Specialized;

namespace AurNet.Http.UrlBuilders
{
    /// <summary>
    /// Builder for 'info' service URL.
    /// </summary>
    public class InfoTypeUrlBuilder : ClientUrlBuilder
    {
        private const string ArgsQueryParamKey = "arg[]";

        private readonly IEnumerable<string> _packages;

        /// <summary>
        /// Instanciate <see cref="InfoTypeUrlBuilder"/>.
        /// </summary>
        /// <param name="packages">Name of the packages to get information from.</param>
        public InfoTypeUrlBuilder(IEnumerable<string> packages)
        {
            _packages = packages;
        }

        protected override string TypeQueryParamValue => "info";

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