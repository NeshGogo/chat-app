using ChatApi.Data;
using ChatApi.Entities;
using ChatApi.GraphQL.Chats;
using ChatApi.GraphQL.Users;

namespace ChatApi.GraphQL
{
    public class Mutations
    {
        public async Task<AddUserPayLoad> AddUserAsync(AddUserInput input, [ScopedService] AppDbContext context)
        {
            var user = new User
            {
                Name = input.Name,
                UserName = input.UserName,
                Email = input.Email,
                Phone = input.Phone,
                PhonePrefix = input.PhonePrefix,
            };
            context.Add(user);
            await context.SaveChangesAsync();
            return new AddUserPayLoad(user);
        }

        public async Task<AddChatPayLoad> AddChatAsync(AddChatInput input, [ScopedService] AppDbContext context)
        {
            var chat = new Chat
            {
                Name = input.Name,
                Users = new List<User>() { input.Users },
            };
            context.Add(chat);
            await context.SaveChangesAsync();
            return new AddChatPayLoad(chat);
        }
    }
}
