using System.Net.Http;
using System.Threading.Tasks;
using AurNet.Models;

namespace AurNet.Http
{
    public class AurHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<string> Search(string arg, SearchField searchField)
        {
            return await this.Call(new SearchTypeUrlBuilder(arg, searchField));
        }

        public async Task<string> Info(string[] args)
        {
            return await this.Call(new InfoTypeUrlBuilder(args));
        }

        private async Task<string> Call(ClientUrlBuilder urlBuilder)
        {
            var url = urlBuilder.Build();
            var response = await Client.GetAsync(url);
            System.Console.WriteLine(response);

            return await response.Content.ReadAsStringAsync();
        }
    }
}