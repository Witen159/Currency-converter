using System;

namespace CurrencyConverter.Web.Logging
{
    public interface ILogger
    {
        void Log(Exception exception);
    }
}