using System;
using System.Threading.Tasks;
using AurNet.App;
using AurNet.Logging.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AurNet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var runner = BuildServices(ConfigureBaseLogging).GetService<IRunner>();

            var isVerbose = runner.IsVerbose(args);
            if (isVerbose)
            {
                runner = BuildServices(ConfigureVerboseLogging).GetService<IRunner>();
            }

            await runner.RunAsync(args);
        }

        private static IServiceProvider BuildServices(Action<ILoggingBuilder> loggingConfig)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<IRunner, Runner>()
                .AddLogging(loggingConfig);

            return serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureBaseLogging(ILoggingBuilder builder)
        {
            builder.AddProvider(new FileLoggerProvider());
        }

        private static void ConfigureVerboseLogging(ILoggingBuilder builder)
        {
            ConfigureBaseLogging(builder);
            builder.AddProvider(new ConsoleLoggerProvider());
        }
    }
}
