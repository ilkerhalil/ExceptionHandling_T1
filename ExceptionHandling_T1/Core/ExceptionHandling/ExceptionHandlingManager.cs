using System;
using ExceptionHandling_T1.Core.Interfaces;

namespace ExceptionHandling_T1.Core.ExceptionHandling
{
    public  class ExceptionHandlingManager
    {
        private readonly ILogger[] _loggers;

        public ExceptionHandlingManager(ILogger[] loggers)
        {
            _loggers = loggers;
        }

       public void HandleException(Exception e)
        {
            if (e is ArgumentException)
                throw e;

            foreach (var logger in _loggers)
            {
                logger.Log(LogLevel.Error, "Bir hata oluştu", new object[] { e });

            }
            throw new Exception("Lütfen sistem yöneticisine başvurun..!");
        }
    }
}
