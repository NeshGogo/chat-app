using ChatApi.Data;
using ChatApi.Entities;
using ChatApi.GraphQL.Chats;
using ChatApi.GraphQL.Users;

namespace ChatApi.GraphQL
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
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
            user.Created("System");
            context.Add(user);
            await context.SaveChangesAsync();
            return new AddUserPayLoad(user);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddChatPayLoad> AddChatAsync(AddChatInput input, [ScopedService] AppDbContext context)
        {
            var chat = new Chat
            {
                Name = input.Name,
                Users = new List<User>() { input.Users },
            };
            chat.Created("System");
            context.Add(chat);
            await context.SaveChangesAsync();
            return new AddChatPayLoad(chat);
        }
    }
}
