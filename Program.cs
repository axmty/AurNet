using System;
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
            var runner = BuildServiceCollection(false)
                .GetService<IRunner>();

            var isVerbose = runner.IsVerbose(args);
            if (isVerbose)
            {
                runner = BuildServiceCollection(true).GetService<IRunner>();
            }

            await runner.RunAsync(args);
        }

        private static IServiceProvider BuildServiceCollection(bool isVerbose)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<IRunner, Runner>();

            if (isVerbose)
            {
                serviceCollection.AddLogging(ConfigureVerboseLogging);
            }
            else
            {
                serviceCollection.AddLogging(ConfigureBaseLogging);
            }

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

    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsolerLogger(categoryName);
        }

        public void Dispose()
        {

        }
    }

    public class FileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName);
        }

        public void Dispose()
        {

        }
    }

    public class Disposable : IDisposable
    {
        public void Dispose()
        {

        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _categoryName;

        public FileLogger(string categoryName)
        {
            _categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new Disposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            Console.WriteLine("FILE: " + message);
        }
    }

    public class ConsolerLogger : ILogger
    {
        private readonly string _categoryName;

        public ConsolerLogger(string categoryName)
        {
            _categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new Disposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            Console.WriteLine("CONSOLE: " + message);
        }
    }
}
