using System.Threading.Tasks;
using AurNet.Command;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AurNet
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                .AddLogging(builder => 
                {
                    builder.AddConsole();
                });

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            await CommandRunner.RunAsync(args);
        }
    }
}
