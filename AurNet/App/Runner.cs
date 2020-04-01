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
        public Task<int> RunAsync(string[] args)
        {
            var verbParser = new Parser(settings =>
            {
                settings.CaseInsensitiveEnumValues = true;
                settings.IgnoreUnknownArguments = true;
            }).ParseArguments<SearchOptions, InfoOptions>(args);

            return verbParser.MapResult(
                (SearchOptions options) => SearchAsync(options),
                (InfoOptions options) => InfoAsync(options),
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

        private Task<int> SearchAsync(SearchOptions options)
        {
            _aurHttpClient.SearchAsync(options.Arg, options.Field);

            return Task.FromResult(0);
        }

        private Task<int> InfoAsync(InfoOptions options)
        {
            _aurHttpClient.InfoAsync(options.Packages.ToArray());

            return Task.FromResult(0);
        }
    }
}
