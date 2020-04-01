using System.Collections.Generic;

namespace AurNet.Http
{
    /// <summary>
    /// Response object returned by the AUR API when called.
    /// </summary>
    public abstract class ApiResponse<TResult>
    {
        public abstract ApiResponseType Type { get; }

        public int Version { get; set; }

        public int ResultCount { get; set; }

        public IEnumerable<TResult> Results { get; set; }
    }
}