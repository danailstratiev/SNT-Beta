﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNT.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SNT.Models;
using SNT.Services;
using CloudinaryDotNet;
using SNT.Services.Mapping;
using SNT.InputModels;
using System.Reflection;
using SNT.ViewModels;
using SNT.ServiceModels;
using SNT.ViewModels.Home;

namespace SNT
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<SntDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<SntUser, IdentityRole>()
                .AddEntityFrameworkStores<SntDbContext>()
                .AddDefaultTokenProviders();

            Account cloudinaryCredentials = new Account(
              this.Configuration["Cloudinary:CloudName"],
              this.Configuration["Cloudinary:ApiKey"],
              this.Configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            services.AddSingleton(cloudinaryUtility);

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
            });

            services.AddTransient<ITyreService, TyreService>();
            services.AddTransient<IWheelRimService, WheelRimService>();
            services.AddTransient<IMotorOilService, MotorOilService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShoppingBagService, ShoppingBagService>();
            services.AddTransient<IReceiptService, ReceiptService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
               typeof(TyreCreateInputModel).GetTypeInfo().Assembly,
               typeof(TyreViewModel).GetTypeInfo().Assembly,
               typeof(TyreServiceModel).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
               typeof(WheelRimCreateInputModel).GetTypeInfo().Assembly,
               typeof(WheelRimViewModel).GetTypeInfo().Assembly,
               typeof(WheelRimServiceModel).GetTypeInfo().Assembly);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<SntDbContext>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new IdentityRole
                        {
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });

                        context.Roles.Add(new IdentityRole
                        {
                            Name = "User",
                            NormalizedName = "USER"
                        });

                        context.SaveChanges();
                    }
                }
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            //This method maps Controllers and Actions
            app.UseMvcWithDefaultRoute();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
