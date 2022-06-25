using CurrencyConverter.Core;

namespace CurrencyConverter.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConverterContext _context;

        public UnitOfWork(ConverterContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}