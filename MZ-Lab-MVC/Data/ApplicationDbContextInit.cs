using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MZ_Lab_MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace MZ_Lab_MVC.Data
{
    public interface IDbInitializer
    {
        void Initialize();
    }

    public class  ApplicationDbContextInit:IDbInitializer
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManger;


        public ApplicationDbContextInit(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManger = roleManager;
        }
        public async void Initialize()
        {
            if(_context.Users.Any())
            {
                return;
            }
            //create database schema if none exists
            _context.Database.EnsureCreated();

            //Create the default Admin account and apply the Administrator role
            string username = "me@myemail.com";
            string password = "Password123?";

            var user = new ApplicationUser { UserName = username, Email = username };
            var result = await _userManager.CreateAsync(user, password);


            if (result.Succeeded)
            {
                
                

            }
        }
    }
}
