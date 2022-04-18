namespace CurrencyConverter.Core
{
    public interface ICurrencyConverter
    {
        int ConvertToRubles(string currencyCode, int amount);
    }
}