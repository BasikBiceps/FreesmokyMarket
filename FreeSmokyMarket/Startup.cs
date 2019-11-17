﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF.Repositories;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Infrastructure.NotificationSenders;
using FreeSmokyMarket.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace FreeSmokyMarket
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddDbContext<FreeSmokyMarketContext>();
            services.AddTransient<ISenderFactory, SenderFactory>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".MyApp.Session";
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            loggerFactory.AddLog4Net();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=MainPage}/{id?}");
            });
        }
    }
}