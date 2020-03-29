﻿using Microsoft.Extensions.Logging;

namespace AurNet.Logging
{
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
