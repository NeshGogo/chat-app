using AutoMapper;
using ChatApi.Dtos;
using ChatApi.Entities;
using ChatApi.GraphQL.Messages;
using ChatApi.GraphQL.Users;

namespace ChatApi.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            // --> User
            CreateMap<User, UserDto>();
            CreateMap<AddUserInput, User>();

            // --> Chat
            CreateMap<Chat, ChatDto>();

            // --> Message
            CreateMap<Message, MessageDto>();
            CreateMap<AddMessageInput, Message>();
        }
    }
}
