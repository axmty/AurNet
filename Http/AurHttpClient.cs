using System.Net.Http;
using System.Threading.Tasks;
using AurNet.Models;

namespace AurNet.Http
{
    public static class AurHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<string> SearchAsync(string arg, SearchField searchField)
        {
            return await CallAsync(new SearchTypeUrlBuilder(arg, searchField));
        }

        public static async Task<string> InfoAsync(string[] packages)
        {
            return await CallAsync(new InfoTypeUrlBuilder(packages));
        }

        private static async Task<string> CallAsync(ClientUrlBuilder urlBuilder)
        {
            var url = urlBuilder.Build();
            var response = await Client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}