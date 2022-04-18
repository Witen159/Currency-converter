namespace CurrencyConverter.Core
{
    public interface ICurrencyConverter
    {
        double ConvertToRubles(string currencyCode, double amount);
        double ConvertFromRubles(string convertingCurrencyCode, double amount);

        double ConvertCurrency(string currencyCode, string convertingCurrencyCode, double amount);
    }
}