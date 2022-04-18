namespace CurrencyConverter.Core
{
    public interface ICourseProvider
    {
        int GetCourse(string currencyCode);
    }
}