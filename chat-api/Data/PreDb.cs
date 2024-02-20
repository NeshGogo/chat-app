using ChatApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data
{
    public static class PreDb
    {
        public static void PrePoupulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                SeedData(context, isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool IsProd)
        {
            try
            {
                Console.WriteLine("--> Seeding data...");
                SeedUsers(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not seeding new users becase of error: {ex.Message}");
            }

            if (IsProd)
            {
                try
                {
                    Console.WriteLine("--> Attempting to apply migrations...");
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations. Error: {ex.Message}");
                }
            }
        }

        private static void SeedUsers(AppDbContext context)
        {
            Console.WriteLine("--> Seeding new users...");
            var users = new List<User>
            {
                new User
                {
                    Name = "Rafae AB",
                    UserName = "neshgogo",
                    Email = "test@test.com",
                    Phone = "8091234421",
                    PhonePrefix = "1",                   
                }
            };

            try
            {
                foreach (var user in users)
                {
                    var exists = context.Set<User>().Any(p => p.UserName == user.UserName);
                    if (!exists)
                    {
                        user.Created("System");
                        context.Add(user);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not seeding new users because of error: {ex.Message}");
            }
        }
    }
}
