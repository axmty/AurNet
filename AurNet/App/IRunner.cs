using System.Threading.Tasks;

namespace AurNet.App
{
    /// <summary>
    /// Perform actions from the command line options.
    /// </summary>
    public interface IRunner
    {
        /// <summary>
        /// Parse the command line arguments into options and execute actions.
        /// </summary>
        /// <param name="args">Command line arguments to parse.</param>
        /// <returns>Exit code of the performed action.</returns>
        Task<int> RunAsync(string[] args);

        /// <summary>
        /// Parse the command line arguments to check whether the 'verbose' option is set.
        /// </summary>
        /// <param name="args">Command line arguments to parse.</param>
        /// <returns>Return true if and only if the 'verbose' option is set.</returns>
        bool IsVerbose(string[] args);
    }
}
