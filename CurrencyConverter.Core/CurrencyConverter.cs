namespace CurrencyConverter.Core
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly ICourseProvider _courseProvider;

        public CurrencyConverter(ICourseProvider courseProvider)
        {
            _courseProvider = courseProvider;
        }

        public double ConvertToRubles(string currencyCode, double amount)
        {
            return _courseProvider.GetCourse(currencyCode) * amount;
        }

        public double ConvertFromRubles(string convertingCurrencyCode, double amount)
        {
            return amount / _courseProvider.GetCourse(convertingCurrencyCode);
        }

        public double ConvertCurrency(string currencyCode, string convertingCurrencyCode, double amount)
        {
            return amount * _courseProvider.GetCourse(currencyCode) / _courseProvider.GetCourse(convertingCurrencyCode);
        }
    }
}