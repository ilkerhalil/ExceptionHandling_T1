using System.Collections.Generic;
using ExceptionHandling_T1.Core.Interfaces;
using ExceptionHandling_T1.Core.LoggerImpl;

namespace ExceptionHandling_T1.Core.ExceptionHandling
{
    public static class ExceptionHandlingManagerFactory
    {
        private static ExceptionHandlingManager _exceptionHandlingManager;
        public static ExceptionHandlingManager CreateExceptionHandlingManager
        {
            get
            {
                if (_exceptionHandlingManager != null) return _exceptionHandlingManager;
                var loggers = new List<ILogger>() { new ConsoleLogger(), new EmailLogger(), new SmsLogger() }.ToArray();
                _exceptionHandlingManager = new ExceptionHandlingManager(loggers);
                return _exceptionHandlingManager;
            }

        }
    }
}
