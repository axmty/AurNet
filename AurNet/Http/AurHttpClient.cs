using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
        public Task<SearchApiResponse> SearchAsync(string arg, SearchField searchField)
        {
            return CallAsync<SearchApiResponse>(new SearchTypeUrlBuilder(arg, searchField));
        }

        /// <inheritdoc/>
        public Task<InfoApiResponse> InfoAsync(string[] packages)
        {
            return CallAsync<InfoApiResponse>(new InfoTypeUrlBuilder(packages));
        }

        private async Task<TResponse> CallAsync<TResponse>(ClientUrlBuilder urlBuilder)
        {
            var url = urlBuilder.Build();
            var response = await _httpClientFactory.CreateClient().GetAsync(url);
            var raw = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(raw);
        }
    }
}