using System;
using CurrencyConverter.Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CurrencyConverter.Data
{
    public class ConverterContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public ConverterContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntity.Map());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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