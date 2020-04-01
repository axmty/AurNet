namespace AurNet.Http
{
    /// <summary>
    /// Base response object returned by the AUR API when called.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Version of the API.
        /// </summary>
        public int Version { get; set; }
    }
}