using System;
using System.IO;

namespace CurrencyConverter.Web.Logging
{
    public class Logger : ILogger
    {
        private readonly string fileName;
        private int count;

        public Logger(string fileName)
        {
            this.fileName = fileName;
        }

        public void Log(Exception exception)
        {
            Console.WriteLine(count++);
            File.AppendAllText(fileName,exception.Message);
        }
    }
}