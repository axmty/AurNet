using System.Linq;
using System.Threading.Tasks;
using AurNet.Http;
using CommandLine;

namespace AurNet.Command
{
    public class CommandRunner
    {
        public static async Task<int> RunAsync(string[] args)
        {
            var verbParser = new Parser(settings =>
                {
                    settings.CaseInsensitiveEnumValues = true;
                    settings.IgnoreUnknownArguments = true;
                })
                .ParseArguments<SearchOptions, InfoOptions>(args);

            return await verbParser.MapResult(
                async (SearchOptions options) => await SearchAsync(options),
                async (InfoOptions options) => await InfoAsync(options),
                errs => Task.FromResult(1)
            );
        }

        public static bool IsVerbose(string[] args)
        {
            var parser = Parser.Default.ParseArguments<VerboseOptions>(args);
            
            return parser.MapResult(
                options => options.IsVerbose,
                _ => false
            );
        }

        private static async Task<int> SearchAsync(SearchOptions options)
        {
            var result = await AurHttpClient.SearchAsync(options.Arg, options.Field);

            return 0;
        }

        private static async Task<int> InfoAsync(InfoOptions options)
        {
            var result = await AurHttpClient.InfoAsync(options.Packages.ToArray<string>());

            return 0;
        }
    }
}
