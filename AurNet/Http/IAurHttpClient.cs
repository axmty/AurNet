using System.Threading.Tasks;

namespace AurNet.Http
{
    /// <summary>
    /// Client that performs calls to the AUR API.
    /// <see href="https://wiki.archlinux.org/index.php/Aurweb_RPC_interface">Details in the wiki.</see>
    /// </summary>
    public interface IAurHttpClient
    {
        /// <summary>
        /// Call the 'search' AUR API.
        /// </summary>
        /// <param name="arg">Keyword to search for.</param>
        /// <param name="searchField">Field by which the search is performed.</param>
        /// <returns>An object that wraps the 'search' success return or an error.</returns>
        Task<ApiResponseWrapper<SearchApiResponse>> SearchAsync(string arg, SearchField searchField);

        /// <summary>
        /// Call the 'info' AUR API.
        /// </summary>
        /// <param name="packages">Name of the packages to search for.</param>
        /// <returns>An object that wraps the 'info' success return or an error.</returns>
        Task<ApiResponseWrapper<InfoApiResponse>> InfoAsync(string[] packages);
    }
}