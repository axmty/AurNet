using Microsoft.Extensions.Logging;

namespace AurNet.Logging
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
