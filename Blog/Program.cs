using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blog
{
    public class Program
    {
        public static  void Main(string[] args)
        {

            var host = CreateWebHostBuilder(args).Build();
            try
            {

                var scope = host.Services.CreateScope();

                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userMn = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleMn = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                db.Database.EnsureCreated();

                var adminRole = new IdentityRole("Admin");
                if (!db.Roles.Any())
                {
                    //create a role
                    roleMn.CreateAsync(adminRole).GetAwaiter().GetResult();
                }


                if (!db.Users.Any(p => p.UserName == "admin4"))
                {
                    //create an admin
                    var adminUser = new IdentityUser
                    {
                        UserName = "admin4",
                        Email = "user@domain.com"
                    };
                    
                    var result = userMn.CreateAsync(adminUser, "password4").GetAwaiter().GetResult(); //len pezull
                    //add role to user
                    userMn.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            host.Run(); 
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
