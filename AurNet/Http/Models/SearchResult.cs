namespace AurNet.Http
{
    /// <summary>
    /// Object representing a 'search' result, contained in the 'results' array of the 'search' response object. 
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Unique identifier of the package.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the package.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Version of the package.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Description of the package.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Number of the votes of the packages.
        /// </summary>
        public int NumVotes { get; set; }
    }
}