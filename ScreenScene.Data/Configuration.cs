﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScreenScene.Data.Context;
using ScreenScene.Data.Entities.Auth;
using ScreenScene.Data.Interfaces;
using ScreenScene.Data.Repository;

namespace ScreenScene.Data
{
    public static class Configuration
    {
        public static void Configure(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ScreenSceneContext>(options => 
                options.UseSqlServer(connectionString));

            serviceCollection.AddDatabaseDeveloperPageExceptionFilter();

            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ScreenSceneContext>()
                .AddDefaultTokenProviders();

            serviceCollection.AddScoped<IScreenSceneDbContext>(provider =>
                    provider.GetRequiredService<ScreenSceneContext>());

            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
