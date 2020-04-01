using System.Collections.Generic;

namespace AurNet.Http
{
    /// <summary>
    /// Type of response returned by the AUR API when called.
    /// </summary>
    public enum ApiResponseType
    {
        /// <summary>
        /// Successful 'search' response.
        /// </summary>
        Search,

        /// <summary>
        /// Successful 'info' response.
        /// </summary>
        MultiInfo,

        /// <summary>
        /// An error occured.
        /// </summary>
        Error,
    }

    /// <summary>
    /// Response object returned by the AUR API when called.
    /// </summary>
    public class ApiResponse<TResult>
    {
        public int Version { get; set; }

        public ApiResponseType Type { get; set; }

        public int ResultCount { get; set; }

        public IEnumerable<TResult> Results { get; set; }
    }

    public class ErrorApiResponse : ApiResponse<int>
    {
        public string Error { get; set; }
    }

    public class SearchApiResponse : ApiResponse<SearchResult>
    {

    }

    public class InfoApiResponse : ApiResponse<InfoResult>
    {

    }

    /// <summary>
    /// Object representing a 'search' result, contained in the 'results' array of the 'search' response object. 
    /// </summary>
    public class SearchResult
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }
    }

    /// <summary>
    /// Object representing an 'info' result, contained in the 'results' array of the 'info' response object. 
    /// </summary>
    public class InfoResult : SearchResult
    {
    }
}