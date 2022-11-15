using Microsoft.AspNetCore.Identity;
using SimpleApp.Constants;
using SimpleApp.Data;

namespace SimpleApp.Seeds;

public static class DefaultRoles
{
    public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
    }
}