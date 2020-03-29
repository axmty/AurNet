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
            var runner = serviceCollection
                .BuildServiceProvider()
                .GetService<IRunner>();

            var isVerbose = runner.IsVerbose(args);
            if (isVerbose)
            {
                runner = ReconfigureVerboseLogging(serviceCollection)
                    .GetService<IRunner>();
            }

            await runner.RunAsync(args);
        }

        private static IServiceCollection BuildServiceCollection()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<IRunner, Runner>()
                .AddLogging(ConfigureBaseLogging);

            return serviceCollection;
        }

        private static ServiceProvider ReconfigureVerboseLogging(IServiceCollection services)
        {
            services.AddLogging(ConfigureVerboseLogging);

            return services.BuildServiceProvider();
        }

        private static void ConfigureBaseLogging(ILoggingBuilder builder)
        {
            
        }

        private static void ConfigureVerboseLogging(ILoggingBuilder builder)
        {
            builder.AddConsole();
        }
    }
}
