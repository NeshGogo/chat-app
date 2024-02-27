using AutoMapper;
using ChatApi.Data;
using ChatApi.Dtos;
using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.GraphQL
{
    public class Query
    {
        private readonly IMapper _mapper;

        public Query(IMapper mapper)
        {
            _mapper = mapper;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UserDto> GetUsers([ScopedService] AppDbContext context) 
        {
            return context.Set<User>().Select(p => _mapper.Map<UserDto>(p)).AsNoTracking();
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ChatDto> GetChats([ScopedService] AppDbContext context)
        {
            return context.Set<Chat>().Include(p => p.Users).Include(p => p.Messages).Select(p => _mapper.Map<ChatDto>(p)).AsNoTracking();
        }
    }
}
