namespace AurNet.Http
{
    /// <summary>
    /// Response object returned by the AUR API when failed.
    /// </summary>
    public class ErrorApiResponse : ApiResponse
    {
        /// <summary>
        /// Error message containing the details of the error.
        /// </summary>
        public string Error { get; set; }
    }
}