using System.Threading.Tasks;
using AurNet.App;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AurNet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var runner = serviceProvider.GetService<IRunner>();
            runner.IsVerbose(args);

            var logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogTrace("TRACE");
            logger.LogDebug("DEBUG");
            logger.LogInformation("INFORMATION");
            logger.LogWarning("WARNING");
            logger.LogError("ERROR");
            logger.LogCritical("CRITICAL");

            await new Runner().RunAsync(args);

            logger.LogTrace("TRACE");
            logger.LogDebug("DEBUG");
            logger.LogInformation("INFORMATION");
            logger.LogWarning("WARNING");
            logger.LogError("ERROR");
            logger.LogCritical("CRITICAL");
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.
                AddLogging(builder => { builder.AddConsole(); });
        }
    }
}
