using CommandLine;

namespace AurNet.Command
{
    public class VerboseOptions
    {
        [Option('v')]
        public bool IsVerbose { get; set; }
    }
}
