using ChatApi.Data;
using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.GraphQL.Users
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Represents any user");
            descriptor.Authorize();
            descriptor.Field(p => p.Chats)
                .ResolveWith<Resolvers>(p => p.GetChats(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("These are the user's chats");
        }

        private class Resolvers
        {
            public IEnumerable<Chat> GetChats([Parent] User user, [ScopedService] AppDbContext context)
             => context.Set<Chat>().Include(p => p.Users).Where(p => p.Users.Any(x => x.Id == user.Id)).ToList();
        }
    }

    
}
