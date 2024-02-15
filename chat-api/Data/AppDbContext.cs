using ChatApi.Data.Chats;
using ChatApi.Data.Messages;
using ChatApi.Data.Users;
using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data
{
    public class AppDbContext : DbContext
    {
        public const string Schema = "ChatApi";
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
            new UserConfig().Configure(modelBuilder.Entity<User>());
            new ChatConfig().Configure(modelBuilder.Entity<Chat>());
            new MessageConfig().Configure(modelBuilder.Entity<Message>());
        }
    }
}
