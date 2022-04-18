namespace CurrencyConverter.Core
{
    public interface ICourseProvider
    {
        double GetCourse(string currencyCode);
    }
}