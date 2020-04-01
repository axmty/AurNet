using System;

namespace AurNet.Http
{
    /// <summary>
    /// Response object returned by the AUR API when failed.
    /// </summary>
    public class ApiErrorResponse : ApiResponse
    {
        /// <summary>
        /// Error message containing the details of the error.
        /// </summary>
        public string FunctionalError { get; set; }

        /// <summary>
        /// Exception thrown while using the HttpClient.
        /// </summary>
        public Exception HttpClientException { get; set; }

        /// <summary>
        /// Tells whether this error is a functional one.
        /// </summary>
        /// <value>True if and only if it is a functional error.</value>
        public bool IsFunctional => this.FunctionalError != null;
    }
}