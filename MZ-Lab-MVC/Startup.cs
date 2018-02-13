using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MZ_Lab_MVC.Data;
using MZ_Lab_MVC.Models;
using MZ_Lab_MVC.Services;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;

namespace MZ_Lab_MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DI for DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<MZLabDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("MZLabDbConnection")));

            //DI for identity services
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //Add Database Initializer
            services.AddScoped<IDbConextInitializer, DbContextInitializer>();

            services.AddMvc();
            
            //authorize Service
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MZLabDbContext context, ApplicationDbContext context_app,IDbConextInitializer initer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //ProxyPass?
            app.UsePathBase("/mzlab");
            app.UseStaticFiles();

            //the Authentication needs ForwardedHeaders middle-ware to run
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //initialize database
            initer.Initialize();
        }
    }
}
