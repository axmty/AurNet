using System;

namespace AurNet.Http
{
    /// <summary>
    /// Response object returned by the AUR API when failed.
    /// </summary>
    public class ApiErrorResponse : ApiResponse
    {
        /// <summary>
        /// Message containing the details of a functional error.
        /// </summary>
        public string FunctionalErrorMessage { get; set; }

        /// <summary>
        /// Exception representing a technical error, like an exception raised while using an HttpClient.
        /// </summary>
        public Exception TechnicalException { get; set; }

        /// <summary>
        /// Tells whether this error is a functional one.
        /// </summary>
        /// <value>True if and only if it is a functional error.</value>
        public bool IsFunctional => this.FunctionalErrorMessage != null;

        /// <summary>
        /// Tells whether this error is a technical one.
        /// </summary>
        /// <value>True if and only if it is a technical error.</value>
        public bool IsTechnical => !this.IsFunctional;
    }
}