using CommandLine;

namespace AurNet.App.Options
{
    public class VerboseOptions
    {
        [Option('v')]
        public bool IsVerbose { get; set; }
    }
}
