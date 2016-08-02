namespace ExceptionHandling_T1.Core.Interfaces
{
    public interface ILogger
    {
        void Log(LogLevel logLevel,string message, object[] parameters);
    }
}
