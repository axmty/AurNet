using CommandLine;

namespace AurNet.App
{
    public class VerboseOptions
    {
        [Option('v')]
        public bool IsVerbose { get; set; }
    }
}
