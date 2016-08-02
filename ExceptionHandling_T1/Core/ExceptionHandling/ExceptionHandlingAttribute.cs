using System;

namespace ExceptionHandling_T1.Core.ExceptionHandling
{
    [AttributeUsage(AttributeTargets.Method,Inherited = true)]
    public class ExceptionHandlingAttribute : Attribute
    {
        private readonly ExceptionHandlingManager _exceptionHandlingManager;

        public ExceptionHandlingAttribute()
        {
            _exceptionHandlingManager = ExceptionHandlingManagerFactory.CreateExceptionHandlingManager;

        }

        public void Execute(Exception exception)
        {
            _exceptionHandlingManager.HandleException(exception);
        }
    }
}
