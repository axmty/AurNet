﻿using AurNet.Models;
using CommandLine;

namespace AurNet.Options
{
    [Verb("search")]
    public class SearchOptions
    {
        [Value(0, Required = true)]
        public string Arg { get; set; }

        [Value(1, Default = SearchField.NameDesc)]
        public SearchField Field { get; set; }
    }
}
