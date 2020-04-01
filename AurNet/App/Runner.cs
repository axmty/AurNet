using System.Linq;
using System.Threading.Tasks;
using AurNet.App.Options;
using AurNet.Http;
using CommandLine;
using Microsoft.Extensions.Logging;

namespace AurNet.App
{
    /// <summary>
    /// Implementation of <see cref="IRunner"/>.
    /// </summary>
    public class Runner : IRunner
    {
        private readonly ILogger<Runner> _logger;

        /// <summary>
        /// Instanciate <see cref="Runner"/>.
        /// </summary>
        /// <param name="logger">Used for logging.</param>
        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<int> RunAsync(string[] args)
        {
            var verbParser = new Parser(settings =>
            {
                settings.CaseInsensitiveEnumValues = true;
                settings.IgnoreUnknownArguments = true;
            }).ParseArguments<SearchOptions, InfoOptions>(args);

            return await verbParser.MapResult(
                async (SearchOptions options) => await SearchAsync(options),
                async (InfoOptions options) => await InfoAsync(options),
                errs => Task.FromResult(1)
            );
        }

        /// <inheritdoc/>
        public bool IsVerbose(string[] args)
        {
            var parser = Parser.Default.ParseArguments<VerboseOptions>(args);

            return parser.MapResult(
                options => options.IsVerbose,
                _ => false
            );
        }

        private static async Task<int> SearchAsync(SearchOptions options)
        {
            await AurHttpClient.SearchAsync(options.Arg, options.Field);

            return 0;
        }

        private static async Task<int> InfoAsync(InfoOptions options)
        {
            await AurHttpClient.InfoAsync(options.Packages.ToArray());

            return 0;
        }
    }
}
