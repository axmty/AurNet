namespace AurNet.Http
{
    /// <summary>
    /// Object representing a 'search' result, contained in the 'results' array of the 'search' response object. 
    /// </summary>
    public class SearchResult
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }
    }
}