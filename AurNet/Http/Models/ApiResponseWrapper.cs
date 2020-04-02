using System;

namespace AurNet.Http
{
    /// <summary>
    /// Wrapper that can hold either a success or an error response.
    /// </summary>
    public class ApiResponseWrapper<TSuccessResponse>
    {
        private ApiResponseWrapper() { }

        /// <summary>
        /// Success response.
        /// </summary>
        public TSuccessResponse SuccessResponse { get; set; }

        /// <summary>
        /// Error response.
        /// </summary>
        /// <value></value>
        public ApiErrorResponse ErrorResponse { get; set; }

        /// <summary>
        /// Returns true if and only if it is a success response.
        /// </summary>
        public bool IsSuccess => this.ErrorResponse == null;

        /// <summary>
        /// Returns true if and only if it is an error response.
        /// </summary>
        public bool IsError => !this.IsSuccess;

        /// <summary>
        /// Create an ApiResponseWrapper that represents a success response.
        /// </summary>
        /// <param name="response">The response from which the wrapper is created.</param>
        /// <returns>The ApiResponseWrapper that represents a success response.</returns>
        public static ApiResponseWrapper<TSuccessResponse> FromSuccessResponse(TSuccessResponse response)
        {
            return new ApiResponseWrapper<TSuccessResponse>
            {
                SuccessResponse = response,
            };
        }

        /// <summary>
        /// Create an ApiResponseWrapper that represents a functional error.
        /// </summary>
        /// <param name="message">The functional error message from which the wrapper is created.</param>
        /// <returns>The ApiResponseWrapper that represents a functional error.</returns>
        public static ApiResponseWrapper<TSuccessResponse> FromFunctionalErrorMessage(string message)
        {
            return new ApiResponseWrapper<TSuccessResponse>
            {
                ErrorResponse = new ApiErrorResponse
                {
                    FunctionalErrorMessage = message,
                },
            };
        }

        /// <summary>
        /// Create an ApiResponseWrapper that represents a technical error.
        /// </summary>
        /// <param name="exception">The technical error exception from which the wrapper is created.</param>
        /// <returns>The ApiResponseWrapper that represents a technical error.</returns>
        public static ApiResponseWrapper<TSuccessResponse> FromTechnicalException(Exception exception)
        {
            return new ApiResponseWrapper<TSuccessResponse>
            {
                ErrorResponse = new ApiErrorResponse
                {
                    TechnicalException = exception,
                },
            };
        }
    }
}