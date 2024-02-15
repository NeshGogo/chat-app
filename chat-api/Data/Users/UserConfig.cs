using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApi.Data.Users
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", AppDbContext.Schema);
            builder.Property(p => p.Name).HasMaxLength(128);
            builder.Property(p => p.Email).HasMaxLength(128);
            builder.Property(p => p.UserName).HasMaxLength(20);
            builder.Property(p => p.Phone).HasMaxLength(10);
            builder.Property(p => p.PhonePrefix).HasMaxLength(5);

            builder.HasMany(p => p.Chats);
        }
    }
}
