using System.Net.Http;
using System.Threading.Tasks;
using AurNet.Http.UrlBuilders;
using AurNet.Models;

namespace AurNet.Http
{
    /// <summary>
    /// Client that performs calls to the AUR API.
    /// <see href="https://wiki.archlinux.org/index.php/Aurweb_RPC_interface">Details in the wiki.</see>
    /// </summary>
    public static class AurHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Call the 'search' AUR API.
        /// </summary>
        /// <param name="arg">Keyword to search for.</param>
        /// <param name="searchField">Field by which the search is performed.</param>
        /// <returns>The raw string response.</returns>
        public static async Task<string> SearchAsync(string arg, SearchField searchField)
        {
            return await CallAsync(new SearchTypeUrlBuilder(arg, searchField));
        }

        /// <summary>
        /// Call the 'info' AUR API.
        /// </summary>
        /// <param name="packages">Name of the packages to search for.</param>
        /// <returns>The raw string response.</returns>
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