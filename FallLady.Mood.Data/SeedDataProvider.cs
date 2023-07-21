using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallLady.Mood.Data.Domain;
using Microsoft.AspNetCore.Identity;

namespace FallLady.Mood.Data
{
    public static class SeedDataProvider
    {
        public static async Task SeedData(this IServiceProvider serviceProvider)
        {
            try
            {
                var scope = serviceProvider.CreateScope();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();


                #region Seed Default Roles

                var existRoleAdmin = await _roleManager.RoleExistsAsync("Admin");
                if (!existRoleAdmin)
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    await _roleManager.CreateAsync(role);
                }
                var existRoleUser = await _roleManager.RoleExistsAsync("User");
                if (!existRoleUser)
                {
                    var role = new IdentityRole();
                    role.Name = "User";
                    await _roleManager.CreateAsync(role);
                }

                #endregion

                #region Create Default Users

                var hasher = new PasswordHasher<User>();
                if (await _userManager.FindByNameAsync("hadese") is null)
                {
                    var user = new User
                    {
                        UserName = "hadese",
                        Email = $"hadese@gmail.com",
                        NormalizedUserName = "hadese".ToUpper(),
                        PasswordHash = hasher.HashPassword(null, "hadese1360"),
                        IsActive = true,
                    };
                    var result = await _userManager.CreateAsync(user);

                    if (result.Succeeded)
                    {
                        // Add To Role
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }


                #endregion

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
