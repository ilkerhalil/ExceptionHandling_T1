using System;
using System.Linq;
using ExceptionHandling_T1.Core.Interfaces;

namespace ExceptionHandling_T1.Core.LoggerImpl
{
    public class ConsoleLogger : ILogger
    {
        public string PhoneNumbers { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }

        public void Log(LogLevel logLevel, string message, object[] parameters)
        {
            var messageParametersValue = string.Join("|", parameters.Select(s => s.ToString()).ToArray());
            Console.WriteLine($"{message} => {messageParametersValue}");
        }



    }
}