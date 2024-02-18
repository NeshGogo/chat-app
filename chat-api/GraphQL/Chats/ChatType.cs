using ChatApi.Data;
using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.GraphQL.Chats
{
    public class ChatType : ObjectType<Chat>
    {
        protected override void Configure(IObjectTypeDescriptor<Chat> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Description("Represents any Chat");
            
            descriptor.Field(p => p.Users)
                .ResolveWith<Resolvers>(p => p.GetUsers(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("These are the chat's users");
           
            descriptor.Field(p => p.Messages)
                .ResolveWith<Resolvers>(p => p.GetMessges(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("These are the chat's messages");
        }

        private class Resolvers
        {
            public IEnumerable<User> GetUsers([Parent] Chat chat, [ScopedService] AppDbContext context)
             => context.Set<User>().Include(p => p.Chats).Where(p => p.Chats.Any(x => x.Id == chat.Id)).ToList();

            public IEnumerable<Message> GetMessges([Parent] Chat chat, [ScopedService] AppDbContext context)
             => context.Set<Message>().Where(p => p.ChatId == chat.Id).ToList();
        }
    }     
}
