﻿using GrocifyApp.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiraShop.DAL.Repositories.Interfaces;

namespace MiraShop.DAL
{
    public static class DependencyInjectionRegistry
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            var useOnlyInMemoryDatabase = false;
            if (configuration["UseOnlyInMemoryDatabase"] != null)
            {
                useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]!);
            }

            //if (useOnlyInMemoryDatabase)
            //{
            //    services.AddDbContextFactory<GrocifyAppContext>(options =>
            //        options.UseInMemoryDatabase("PeerGroup"));

            //    services.AddDbContextFactory<AppIdentityDbContext>(options =>
            //        options.UseInMemoryDatabase("Identity"));
            //}
            //else
            //{
            services.AddDbContextFactory<MiraShopAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                     x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            //}

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
