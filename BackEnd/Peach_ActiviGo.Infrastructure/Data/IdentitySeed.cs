using Microsoft.AspNetCore.Identity;

namespace Peach_ActiviGo.Infrastructure.Data
{
    public static class IdentitySeed
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // --- Roller ---
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            // --- Admin ---
            var admin = await userManager.FindByEmailAsync("kimpabooy@live.com");
            if (admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = "kimpabooy@live.com",
                    Email = "kimpabooy@live.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(admin, "Abc123!!");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // --- Övriga användare ---
            await CreateUserIfNotExist(userManager, "user1@example.com", "User123!");
            await CreateUserIfNotExist(userManager, "user2@example.com", "User123!");
            await CreateUserIfNotExist(userManager, "user3@example.com", "User123!");
            await CreateUserIfNotExist(userManager, "user4@example.com", "User123!");
        }

        // Metod för att skapa användare om de inte redan finns.
        private static async Task CreateUserIfNotExist(UserManager<IdentityUser> userManager, string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}