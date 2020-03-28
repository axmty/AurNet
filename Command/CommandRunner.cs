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
                .ParseArguments<SearchOptions, object>(args);

            return await verbParser.MapResult(
                async (SearchOptions options) => await Search(options),
                errs => Task.FromResult(1)
            );
        }

        private static async Task<int> Search(SearchOptions options)
        {
            System.Console.WriteLine(options.Arg);
            System.Console.WriteLine(options.Field);
            var client = new AurHttpClient();
            var response = await client.Search(options.Arg, options.Field);

            return 0;
        }
    }
}
