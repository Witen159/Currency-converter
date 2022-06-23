using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyConverter.Data.Users
{
    [Table("user")]
    public class UserEntity
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
        
        internal class Map : IEntityTypeConfiguration<UserEntity>
        {
            public void Configure(EntityTypeBuilder<UserEntity> builder)
            {
                builder.Property(x => x.Id)
                    .HasColumnName("id");

                builder.HasKey(x => x.Id)
                    .HasName("pk_id");
            }
        }
    }
}