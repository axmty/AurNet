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
            var serviceCollection = BuildServiceCollection();
            serviceCollection.AddLogging(ConfigureBaseLogging);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var runner = serviceProvider.GetService<IRunner>();

            var isVerbose = runner.IsVerbose(args);
            if (isVerbose)
            {
                serviceCollection.AddLogging(ConfigureVerboseLogging);
                serviceProvider = serviceCollection.BuildServiceProvider();
            }

            await new Runner().RunAsync(args);
        }

        private static IServiceCollection BuildServiceCollection()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<IRunner, Runner>();

            return serviceCollection;
        }

        private static void ConfigureBaseLogging(ILoggingBuilder builder)
        {
            
        }

        private static void ConfigureVerboseLogging(ILoggingBuilder builder)
        {
            ConfigureBaseLogging(builder);
            builder.AddConsole();
        }
    }
}
