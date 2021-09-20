using ExpenseManagement.Data.Contexts;
using ExpenseManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Seeders
{
    public class Seeder
    {
        public static async Task Seed(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ExpenseManagementDbContext dbContext)
        {
            await dbContext.Database.EnsureCreatedAsync();
            if (!dbContext.Users.Any())
            {
                List<string> roles = new List<string> { "Admin", "Regular" };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }

                List<User> users = new List<User>
                {
                    new User
                    {
                        FirstName = "Ayebakuro",
                        LastName = "Ombu",
                        Email = "xplicitkuro@gmail.com",
                        UserName = "ice",
                        PhoneNumber = "070843584630"
                    },
                    new User
                    {
                        FirstName = "Dienebi",
                        LastName = "Ombu",
                        Email = "ebidien@gmail.com",
                        UserName = "dings",
                        PhoneNumber = "071843584630"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Insight@1");
                    if (user == users[0])
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "Regular");
                    }
                }
            }
        }
    }
}
