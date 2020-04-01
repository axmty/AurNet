using System;
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
        private const string ErrorType = "error";
        private readonly IHttpClientFactory _httpClientFactory;

        public AurHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <inheritdoc/>
        public Task<ApiResponseWrapper<SearchApiResponse>> SearchAsync(string arg, SearchField searchField)
        {
            return this.CallAsync<SearchApiResponse>(new SearchTypeUrlBuilder(arg, searchField));
        }

        /// <inheritdoc/>
        public Task<ApiResponseWrapper<InfoApiResponse>> InfoAsync(string[] packages)
        {
            return this.CallAsync<InfoApiResponse>(new InfoTypeUrlBuilder(packages));
        }

        private async Task<ApiResponseWrapper<TSuccessResponse>> CallAsync<TSuccessResponse>(
            ClientUrlBuilder urlBuilder)
        {
            var url = urlBuilder.Build();
            var client = _httpClientFactory.CreateClient();

            try
            {
                var message = await client.GetAsync(url);
                var raw = await message.Content.ReadAsStringAsync();
                var parsed = JsonSerializer.Deserialize<TSuccessResponse>(raw);

                return ApiResponseWrapper<TSuccessResponse>.FromSuccessResponse(parsed);
            }
            catch (Exception technicalException)
            {
                return ApiResponseWrapper<TSuccessResponse>.FromTechnicalException(technicalException);
            }
        }
    }
}