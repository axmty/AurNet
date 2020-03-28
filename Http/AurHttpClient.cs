using System.Net.Http;
using System.Threading.Tasks;
using AurNet.Models;

namespace AurNet.Http
{
    public static class AurHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<string> Search(string arg, SearchField searchField)
        {
            return await Call(new SearchTypeUrlBuilder(arg, searchField));
        }

        public static async Task<string> Info(string[] packages)
        {
            return await Call(new InfoTypeUrlBuilder(packages));
        }

        private static async Task<string> Call(ClientUrlBuilder urlBuilder)
        {
            var url = urlBuilder.Build();
            var response = await Client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}