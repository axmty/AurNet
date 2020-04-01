namespace AurNet.Http
{
    /// <summary>
    /// Wrapper that can hold either a success or an error response.
    /// </summary>
    public class ApiResponseWrapper<TSuccessResponse>
    {
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
        public bool IsSuccess => this.ErrorResponse != null;

        /// <summary>
        /// Returns true if and only if it is an error response.
        /// </summary>
        public bool IsError => !this.IsSuccess;
    }
}