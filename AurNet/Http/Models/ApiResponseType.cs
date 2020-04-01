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
}