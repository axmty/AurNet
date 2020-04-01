using System.Collections.Generic;

namespace AurNet.Http
{
    /// <summary>
    /// Base response object returned by the AUR API when succeeded.
    /// </summary>
    public class ApiSuccessResponse<TResult> : ApiResponse
    {
        /// <summary>
        /// Number of results returned.
        /// </summary>
        public int ResultCount { get; set; }

        /// <summary>
        /// Results returned.
        /// </summary>
        public IEnumerable<TResult> Results { get; set; }
    }
}