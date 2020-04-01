using Microsoft.Extensions.Logging;

namespace AurNet.Logging
{
    /// <summary>
    /// Provider that allows to log into the console.
    /// </summary>
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
