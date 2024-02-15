using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApi.Data.Messages
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages", AppDbContext.Schema);
            builder.Property(p => p.Content).HasMaxLength(1500);
            builder.Property(p => p.ChatId).HasMaxLength(36);
            builder.Property(p => p.UserId).HasMaxLength(36);

            builder.HasOne(p => p.Chat);
            builder.HasOne(p => p.User);
        }
    }
}
