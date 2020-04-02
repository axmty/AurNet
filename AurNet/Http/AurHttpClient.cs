using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AurNet.Http
{
    /// <summary>
    /// Implementation of <see cref="IAurHttpClient"/>.
    /// </summary>
    public class AurHttpClient : IAurHttpClient
    {
        private const string JsonErrorKey = "error";
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
            ApiResponseWrapper<TSuccessResponse> responseWrapper;

            try
            {
                var message = await _httpClientFactory.CreateClient().GetAsync(url);
                var raw = await message.Content.ReadAsStringAsync();
                var errorMessage = this.FindError(raw);
                if (errorMessage != null)
                {
                    responseWrapper = ApiResponseWrapper<TSuccessResponse>.FromFunctionalErrorMessage(errorMessage);
                }

                var parsed = JsonConvert.DeserializeObject<TSuccessResponse>(raw);
                responseWrapper = ApiResponseWrapper<TSuccessResponse>.FromSuccessResponse(parsed);
            }
            catch (Exception technicalException)
            {
                responseWrapper = ApiResponseWrapper<TSuccessResponse>.FromTechnicalException(technicalException);
            }

            return responseWrapper;
        }

        private string FindError(string raw)
        {
            var json = JObject.Parse(raw);

            return (string)json[JsonErrorKey];
        }
    }
}