using System.Collections.Specialized;

namespace AurNet.Http
{
    public class InfoTypeUrlBuilder : ClientUrlBuilder
    {
        private const string ArgsQueryParamKey = "arg[]";

        private readonly string[] _args;

        public InfoTypeUrlBuilder(string[] args)
        {
            _args = args;
        }

        public override string TypeQueryParamValue => "info";

        protected override NameValueCollection GetTypeQueryParams()
        {
            var query = new NameValueCollection();
            foreach (var arg in _args)
            {
                query.Add(ArgsQueryParamKey, arg);
            }

            return query;
        }
    }
}