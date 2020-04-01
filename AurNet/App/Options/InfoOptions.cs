using System.Collections.Generic;
using CommandLine;

namespace AurNet.App
{
    /// <summary>
    /// Options for 'info' verb.
    /// </summary>
    [Verb("info")]
    public class InfoOptions
    {
        /// <summary>
        /// Name of the packages to get information of.
        /// </summary>
        [Value(0, Min = 1)]
        public IEnumerable<string> Packages { get; set; }
    }
}
