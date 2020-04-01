namespace AurNet.Http
{
    /// <summary>
    /// Type of response returned by the AUR API when called.
    /// </summary>
    public enum AurApiResponseType
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

    /// <summary>
    /// Response object returned by the AUR API when called.
    /// </summary>
    public class AurApiResponse
    {
        public int Version { get; set; }

        public AurApiResponseType Type { get; set; }

        public int Count { get; set; }
    }
}