using System;
using System.Diagnostics;
using System.Linq;
using ExceptionHandling_T1.Core.Interfaces;

namespace ExceptionHandling_T1.Core.LoggerImpl
{
    public class EmailLogger : ILogger
    {
        public string ToEmailAddress { get; set; }
        public string Subject { get; set; }
        public string CcEmailAddress { get; set; }
        public string BccEmailAddress { get; set; }

        public string From { get; set; }


        public void Log(LogLevel logLevel, string message, object[] parameters)
        {
            var messageParametersValue = string.Join("|",parameters.Select(s => s.ToString()).ToArray());
            Debug.WriteLine($"{message} => {messageParametersValue}");
        }
        private static void SendSms(Exception exception)
        {
            Console.WriteLine($"Hata Oluþtu sms attým. {exception}");
        }

        
        private static void Log(Exception exception)
        {
            Console.WriteLine($"Hata Oluþtu {exception}");
        }
    }
}