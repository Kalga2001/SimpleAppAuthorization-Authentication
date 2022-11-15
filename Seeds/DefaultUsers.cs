using Microsoft.AspNetCore.Identity;
using SimpleApp.Constants;
using SimpleApp.Data;
using System;
using System.Security.Claims;

namespace SimpleApp.Seeds;


public static class DefaultUsers
{
    public static async Task SeedAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        var defaultUser = new User
        {
            UserName = "mishakalga@gmail.com",
            Email = "mishakalga@gmail.com",
            FirstName = "Mihail",
            LastName = "Balta",
            IsActive = true,
            IsDeleted = false,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
            }

        }
    }

}
