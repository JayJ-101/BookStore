using Microsoft.AspNetCore.Identity;
using System;

namespace BookStore.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>();

            string username = "admin";
            string password = "Sinaye";
            string roleName = "Admin";

            //if role doesnt exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
                await roleManager.CreateAsync(new IdentityRole(roleName));


            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result  =await userManager.CreateAsync(user, password);

                if(result.Succeeded)
                    await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
