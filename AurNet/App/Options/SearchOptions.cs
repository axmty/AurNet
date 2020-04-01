using AurNet.Http;
using CommandLine;

namespace AurNet.App
{
    /// <summary>
    /// Options for 'search' verb.
    /// </summary>
    [Verb("search")]
    public class SearchOptions
    {
        /// <summary>
        /// The argument to search for.
        /// </summary>
        [Value(0, Required = true)]
        public string Arg { get; set; }

        /// <summary>
        /// The field by which the search is performed.
        /// </summary>
        [Value(1, Default = SearchField.NameDesc)]
        public SearchField Field { get; set; }
    }
}
