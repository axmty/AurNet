using System.Linq;
using System.Threading.Tasks;
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
        private readonly IAurHttpClient _aurHttpClient;
        private readonly ILogger<Runner> _logger;

        /// <summary>
        /// Instanciate <see cref="Runner"/>.
        /// </summary>
        /// <param name="aurHttpClient">Used to perform calls to AUR APIs.</param>
        /// <param name="logger">Used for logging.</param>
        public Runner(
            IAurHttpClient aurHttpClient,
            ILogger<Runner> logger)
        {
            _aurHttpClient = aurHttpClient;
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

        private async Task<int> SearchAsync(SearchOptions options)
        {
            await _aurHttpClient.SearchAsync(options.Arg, options.Field);

            return 0;
        }

        private async Task<int> InfoAsync(InfoOptions options)
        {
            await _aurHttpClient.InfoAsync(options.Packages.ToArray());

            return 0;
        }
    }
}
