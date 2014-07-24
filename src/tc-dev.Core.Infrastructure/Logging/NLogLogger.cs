using System;
using NLog;
using tc_dev.Core.Service;

namespace tc_dev.Core.Infrastructure.Logging
{
    public class NLogLogger : ILogger
    {
        private static readonly Lazy<NLogLogger> LazyLogger = 
            new Lazy<NLogLogger>(() => new NLogLogger());
        private static readonly Lazy<NLog.Logger> LazyNLogger = 
            new Lazy<Logger>(LogManager.GetCurrentClassLogger);

        private NLogLogger() { }

        public static ILogger Instance {
            get { return LazyLogger.Value; }
        }

        public void Log(string message) {
            LazyNLogger.Value.Info(message);
        }

        public void Log(Exception exception) {
            LazyNLogger.Value.Error(exception);
        }
    }
}
