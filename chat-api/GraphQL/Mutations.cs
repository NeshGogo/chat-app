using AutoMapper;
using ChatApi.Data;
using ChatApi.Dtos;
using ChatApi.Entities;
using ChatApi.Exceptions;
using ChatApi.GraphQL.Chats;
using ChatApi.GraphQL.Messages;
using ChatApi.GraphQL.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.GraphQL
{
    public class Mutations
    {
        private readonly IMapper _mapper;

        public Mutations( IMapper mapper)
        {
            _mapper = mapper;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddUserPayLoad> AddUserAsync(AddUserInput input, [ScopedService] AppDbContext context)
        {
            var user = _mapper.Map<User>(input);
            user.Created("System");
            context.Add(user);
            await context.SaveChangesAsync();
            return new AddUserPayLoad(_mapper.Map<UserDto>(user));
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddChatPayLoad> AddChatAsync(AddChatInput input, [ScopedService] AppDbContext context)
        {
            if(input.UserIds.Count <= 1)
                throw new ErrorMessageException("There must be at lest two users to create a new chat");

            var users = context.Set<User>().Where(p => input.UserIds.Contains(p.Id.ToString())).ToList();
           
            if (users.Count() != input.UserIds.Count)
                throw new ErrorMessageException("One or more of the users send do not exists.");
            var newUsers = new List<User>(users);
            var chat = new Chat
            {
                Name = input.Name,
                Users = newUsers,
            };

            chat.Created("System");
            context.Add(chat);
            await context.SaveChangesAsync();
            return new AddChatPayLoad(_mapper.Map<ChatDto>(chat));
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddMessagePayLoad> AddMessageAsync(AddMessageInput input, [ScopedService] AppDbContext context)
        {
            var user = context.Set<User>().Find(input.UserId);

            if (user == null)
                throw new ErrorMessageException($"We could not find the user with Id {input.UserId}.");

            var chat = context.Set<Chat>().Include(p => p.Users).FirstOrDefault(p => p.Id == input.ChatId);

            if (chat == null)
                throw new ErrorMessageException($"We could not find the chat with Id {input.UserId}.");

            if (!chat.Users.Any(p => p.Id == input.UserId))
                throw new ErrorMessageException($"We could not find the user with Id {input.UserId} in the chat.");

            var message = _mapper.Map<Message>(input);

            message.Created("System");
            context.Add(message);
            await context.SaveChangesAsync();
            return new AddMessagePayLoad(_mapper.Map<MessageDto>(message));
        }
    }
}
