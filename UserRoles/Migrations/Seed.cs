using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UserRoles.Models;

namespace UserRoles.Data
{
    public class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //Add custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "Seller", "Technical", "Banker", "Cl_ATM", "Cl_Location", "Cl_WC", "Cl_Provider", "Client" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Creates Admin

            //var powerUser = new ApplicationUser
            //{
            //    UserName = Configuration.GetSection("UserSettings")["UserEmail"],
            //    Email = Configuration.GetSection("UserSettings")["UserEmail"],
            //    EmailConfirmed = true
            //};

            //string userPassword = Configuration.GetSection("UserSettings")["UserPassword"];
            //var _user = await UserManager
            //    .FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);

            //if (_user == null)
            //{
            //    var createPowerUser = await UserManager.CreateAsync(powerUser, userPassword);

            //    if (createPowerUser.Succeeded)
            //    {
            //        await UserManager.AddToRoleAsync(powerUser, "Admin");
            //    }
            //}


        }
    }
}
