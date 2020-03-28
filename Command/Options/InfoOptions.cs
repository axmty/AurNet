﻿using System.Collections.Generic;
using CommandLine;

namespace AurNet.Command
{
    [Verb("info")]
    public class InfoOptions : BaseOptions
    {
        [Value(0, Min = 1)]
        public IEnumerable<string> Packages { get; set; }
    }
}
