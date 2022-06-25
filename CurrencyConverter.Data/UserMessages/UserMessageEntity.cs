using CurrencyConverter.Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyConverter.Data.UserMessages
{
    public class UserMessageEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public string Text { get; set; }

        internal class Map : IEntityTypeConfiguration<UserMessageEntity>
        {
            public void Configure(EntityTypeBuilder<UserMessageEntity> builder)
            {
                builder.ToTable("user_message");

                builder.Property(x => x.Id).HasColumnName("id");
                builder.Property(x => x.Text).HasColumnName("text");

                builder.HasKey(x => x.Id);

                builder.HasOne(x => x.User)
                    .WithMany(x => x.Messages)
                    .HasForeignKey(x => x.UserId);

                builder.Property(x => x.UserId).HasColumnName("user_id");
            }
        }
    }
}