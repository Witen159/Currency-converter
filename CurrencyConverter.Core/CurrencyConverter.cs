namespace CurrencyConverter.Core
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly ICourseProvider _courseProvider;

        public CurrencyConverter(ICourseProvider courseProvider)
        {
            _courseProvider = courseProvider;
        }

        public int ConvertToRubles(string currencyCode, int amount)
        {
            return _courseProvider.GetCourse(currencyCode) * amount;
        }
    }
}