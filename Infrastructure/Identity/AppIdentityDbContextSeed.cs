using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser 
                {
                    DisplayName = "Abhinav", 
                    Email = "abhd@test.com",
                    UserName = "abhd@test.com",
                    Address = new Address
                    {
                        FirstName = "Abhinav",
                        LastName = "Dubey",
                        Street = "Nauka Vihar",
                        City = "Moradabad",
                        State = "UP",
                        ZipCode = "244011"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}