using System;
using System.Net.Http;

namespace AurNet
{
    public static class AurHttpClientConfig
    {
        public const string Baseurl = "https://aur.archlinux.org/rpc/";
        public const int Version = 5;
        public const string SearchTypeName = "search";
        public const string InfoTypeName = "info";
    }
}

namespace AurNet
{
    public class AurHttpClient
    {
        private static readonly HttpClient HttpClient = new HttpClient()
        {
            BaseAddress = new Uri(AurHttpClientConfig.Baseurl)
        };
    }
}