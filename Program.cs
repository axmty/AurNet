using System.Threading.Tasks;
using AurNet.Http;
using AurNet.Options;
using CommandLine;

namespace AurNet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var options = await (new Parser(settings =>
                {
                    settings.CaseInsensitiveEnumValues = true;
                })
                .ParseArguments<SearchOptions, object>(args)
                .MapResult(
                    async (SearchOptions options) => await Search(options),
                    errs => Task.FromResult(1)
                ));
        }

        private static async Task<int> Search(SearchOptions options)
        {
            var client = new AurHttpClient();
            var response = await client.Search(options.Arg, options.Field);

            return 0;
        }
    }
}
