using System.Net.Http;
using System.Threading.Tasks;
using AurNet.Http.UrlBuilders;
using AurNet.Models;

namespace AurNet.Http
{
    /// <summary>
    /// Implementation of <see cref="IAurHttpClient"/>.
    /// </summary>
    public class AurHttpClient : IAurHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AurHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <inheritdoc/>
        public async Task<string> SearchAsync(string arg, SearchField searchField)
        {
            return await CallAsync(new SearchTypeUrlBuilder(arg, searchField));
        }

        /// <inheritdoc/>
        public async Task<string> InfoAsync(string[] packages)
        {
            return await CallAsync(new InfoTypeUrlBuilder(packages));
        }

        private async Task<string> CallAsync(ClientUrlBuilder urlBuilder)
        {
            var url = urlBuilder.Build();
            var response = await _httpClientFactory.CreateClient().GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}