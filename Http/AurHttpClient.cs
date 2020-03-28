using System.Net.Http;
using System.Threading.Tasks;

namespace AurNet.Http
{
    public class AurHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<string> Search(string arg, SearchField searchField)
        {
            var url = (new SearchTypeUrlBuilder(arg, searchField)).Build();
            var response = await Client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Info(string[] args)
        {
            var url = (new InfoTypeUrlBuilder(args)).Build();
            var response = await Client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}