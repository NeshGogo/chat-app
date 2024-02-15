using ChatApi.Data;
using ChatApi.Entities;

namespace ChatApi.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext context) 
        {
            return context.Set<User>();
        }
    }
}
