using AurNet.Logging.Loggers;
using Microsoft.Extensions.Logging;

namespace AurNet.Logging.Providers
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        public void Dispose()
        {
        }
    }
}
