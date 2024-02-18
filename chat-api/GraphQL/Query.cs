using ChatApi.Data;
using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext context) 
        {
            return context.Set<User>().AsNoTracking();
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Chat> GetChats([ScopedService] AppDbContext context)
        {
            return context.Set<Chat>().Include(p => p.Users).Include(p => p.Messages).AsNoTracking();
        }
    }
}
