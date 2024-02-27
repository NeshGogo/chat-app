using AutoMapper;
using ChatApi.Dtos;
using ChatApi.Entities;
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
        }
    }
}
