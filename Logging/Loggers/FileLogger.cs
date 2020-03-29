using System;
using Microsoft.Extensions.Logging;

namespace AurNet.Logging.Loggers
{
    public class FileLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return new VoidDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
        }
    }
}
