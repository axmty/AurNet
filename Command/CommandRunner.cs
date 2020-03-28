using System.Linq;
using System.Threading.Tasks;
using AurNet.Http;
using CommandLine;

namespace AurNet.Command
{
    public class CommandRunner
    {
        public static async Task<int> Run(string[] args)
        {
            var verbParser = new Parser(settings =>
                {
                    settings.CaseInsensitiveEnumValues = true;
                    settings.IgnoreUnknownArguments = true;
                })
                .ParseArguments<SearchOptions, InfoOptions>(args);

            return await verbParser.MapResult(
                async (SearchOptions options) => await Search(options),
                async (InfoOptions options) => await Info(options),
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

        private static async Task<int> Search(SearchOptions options)
        {
            var result = await AurHttpClient.Search(options.Arg, options.Field);

            return 0;
        }

        private static async Task<int> Info(InfoOptions options)
        {
            var result = await AurHttpClient.Info(options.Packages.ToArray<string>());

            return 0;
        }
    }
}
