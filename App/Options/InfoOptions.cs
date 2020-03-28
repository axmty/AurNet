using System.Collections.Generic;
using CommandLine;

namespace AurNet.App
{
    [Verb("info")]
    public class InfoOptions
    {
        [Value(0, Min = 1)]
        public IEnumerable<string> Packages { get; set; }
    }
}
