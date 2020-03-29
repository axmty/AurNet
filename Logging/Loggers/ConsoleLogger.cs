using System;
using Microsoft.Extensions.Logging;

namespace AurNet.Logging
{
    public class ConsoleLogger : ILogger
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
            Console.ForegroundColor = ColorFromLogLevel(logLevel);

            var message = formatter(state, exception);
            Console.WriteLine(message);
            
            Console.ResetColor();
        }

        private ConsoleColor ColorFromLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Critical => ConsoleColor.DarkRed,
                _ => ConsoleColor.White,
            };
        }
    }
}
