using System.Collections.Generic;
using CommandLine;

namespace AurNet.App.Options
{
    /// <summary>
    /// Options for 'info' verb.
    /// </summary>
    [Verb("info")]
    public class InfoOptions
    {
        /// <summary>
        /// Name of the packages to get information from.
        /// </summary>
        [Value(0, Min = 1)]
        public IEnumerable<string> Packages { get; set; }
    }
}
