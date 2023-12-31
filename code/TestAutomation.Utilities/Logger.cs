﻿using Serilog;

namespace TestAutomation.Utilities
{
    public static class Logger
    {
        private static ILogger _logger;

        public static void Info(string message)
        {
            _logger.Information(message);
        }

        public static void InitLogger(string loggerName, string pathToFolder  = null)
        {
            if (pathToFolder == null) 
            {
                pathToFolder = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), "logs");
            }           

            Directory.CreateDirectory(pathToFolder);

            _logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(pathToFolder, loggerName + ".txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }
    }
}
