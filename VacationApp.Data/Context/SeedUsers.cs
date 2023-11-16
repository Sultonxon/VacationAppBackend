using Microsoft.AspNetCore.Identity;
using VacationApp.Common.Entities;

namespace VacationApp.Data.Context;

public class SeedUsers
{
    public static async Task SeedAdmin(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager, string password)
    {
        if ((await userManager.FindByEmailAsync("admin@gmail.com")) is not null)
        {
            return;
        }
        
        var admin = new UserEntity
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "admin",
            Email = "admin@gmail.com"
        };
        
        var result = await userManager.CreateAsync(admin, password);

        if (result.Succeeded)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            await userManager.AddToRoleAsync(admin, adminRole.Name);
        }
    }
}