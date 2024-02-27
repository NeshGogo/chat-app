﻿using AutoMapper;
using ChatApi.Data;
using ChatApi.Dtos;
using ChatApi.Entities;
using ChatApi.GraphQL.Chats;
using ChatApi.GraphQL.Users;

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
