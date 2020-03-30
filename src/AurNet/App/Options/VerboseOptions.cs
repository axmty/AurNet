using CommandLine;

namespace AurNet.App.Options
{
    /// <summary>
    /// Verbose command line option.
    /// </summary>
    public class VerboseOptions
    {
        /// <summary>
        /// Verbose option.
        /// </summary>
        /// <value>True if and only if the verbose option is set.</value>
        [Option('v')]
        public bool IsVerbose { get; set; }
    }
}
