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
        public async Task<SearchApiResponse> SearchAsync(string arg, SearchField searchField)
        {
            return await CallAsync<SearchApiResponse>(new SearchTypeUrlBuilder(arg, searchField));
        }

        /// <inheritdoc/>
        public async Task<InfoApiResponse> InfoAsync(string[] packages)
        {
            return await CallAsync<InfoApiResponse>(new InfoTypeUrlBuilder(packages));
        }

        private async Task<TApiSuccessResponse> CallAsync<TApiSuccessResponse>(ClientUrlBuilder urlBuilder)
        {
            var url = urlBuilder.Build();
            var response = await _httpClientFactory.CreateClient().GetAsync(url);
            var raw = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TApiSuccessResponse>(raw);
        }
    }
}