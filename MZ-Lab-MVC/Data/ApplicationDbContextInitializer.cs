using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MZ_Lab_MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace MZ_Lab_MVC.Data
{

    public static class  ApplicationDbContextInitializer
    {

        public static void Initialize(this ApplicationDbContext context)
        {

            //context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var role = new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "",
            };
            context.Roles.AddRange(role);
            context.SaveChanges();

            var user = new ApplicationUser()
            {
                Id = new Guid().ToString(),
                AccessFailedCount = 0,
                ConcurrencyStamp = new Guid().ToString(),
                Email = "MZLabAdmin@gmail.com",
                EmailConfirmed = false,
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedEmail = "MZLabAdmin@gmail.com",
                NormalizedUserName = "MZLabAdmin@gmail.com",
                PasswordHash = "AQAAAAEAACcQAAAAELgyWsOfUKhVRAh+l6bn3+jmkCIXsy2QufXQ7U2ludAAQM479HfNTs//IuUvAGJxmw==",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                SecurityStamp = "78a426b1-9c6e-4c7d-9526-69f0fcc96bbe",
                TwoFactorEnabled = false,
                UserName = "MZLabAdmin@gmail.com",
            };
            context.Users.AddRange(user);
            context.SaveChanges();

            var userRole = new IdentityUserRole<string>()
            {
                RoleId = context.Roles.Where(r => r.Name == "Admin").FirstOrDefault().Id,
                UserId = context.Users.Where(u => u.UserName == "MZLabAdmin@gmail.com").FirstOrDefault().Id
            };
            context.UserRoles.AddRange(userRole);
            context.SaveChanges();
        }
    }
}
