using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Data;

namespace SimpleApp
{
    public static class HostExtension
    {
            public static async Task SeedData(this IHost host)
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager= services.GetRequiredService<RoleManager<IdentityRole>>();
                    context.Database.Migrate();

                        await Seeds.DefaultRoles.SeedRolesAsync(userManager,roleManager);
                        await Seeds.DefaultUsers.SeedAdminAsync(userManager,roleManager);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occured during migration");
                    }
                }
            }
        }
}
