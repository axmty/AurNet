using Microsoft.Extensions.Logging;

namespace AurNet.Logging
{
    /// <summary>
    /// Provider that allows to log into a file.
    /// </summary>
    public class FileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger();
        }

        public void Dispose()
        {
        }
    }
}
