namespace CurrencyConverter.Core
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}