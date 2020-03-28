using CommandLine;

namespace AurNet.Command
{
    public class BaseOptions
    {
        [Option('v')]
        public bool Verbose { get; set; }
    }
}
