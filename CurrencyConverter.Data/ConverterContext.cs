using System;
using System.Linq;
using CurrencyConverter.Data.UserMessages;
using CurrencyConverter.Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CurrencyConverter.Data
{
    /// <summary>
    /// Только для чтения
    /// </summary>
    public class ConverterReadonlyContext : DbContext
    {
        public IQueryable<UserEntity> Users => Set<UserEntity>().AsNoTracking();

        public override int SaveChanges()
        {
            throw new Exception("Read only context");
        }
    }
    
    public class ConverterContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public ConverterContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConverterContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class Factory : IDesignTimeDbContextFactory<ConverterContext>
    {
        public ConverterContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql("Host=localhost;Port=5432;Database=converter-test;Username=postgres;Password=Madmanp159")
                .Options;

            return new ConverterContext(options);
        }
    }
}