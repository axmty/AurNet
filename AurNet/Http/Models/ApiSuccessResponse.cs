using System.Collections.Generic;

namespace AurNet.Http
{
    /// <summary>
    /// Response object returned by the AUR API when called.
    /// </summary>
    public class ApiSuccessResponse<TResult> : ApiResponse
    {
        public int ResultCount { get; set; }

        public IEnumerable<TResult> Results { get; set; }
    }
}