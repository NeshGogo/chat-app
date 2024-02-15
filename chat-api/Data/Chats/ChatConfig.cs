using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApi.Data.Chats
{
    public class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chats", AppDbContext.Schema);
            builder.Property(p => p.Name).HasMaxLength(128);

            builder.HasMany(p => p.Users);
            builder.HasMany(p => p.Messages);
        }
    }
}
