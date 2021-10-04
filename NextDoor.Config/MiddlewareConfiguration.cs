using Microsoft.Extensions.DependencyInjection;
using NextDoor.DataLayer;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Services;
using NextDoor.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NextDoor.Infrastructure.Managers;
using NextDoor.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.DataLayer.Repositories;
using UserManagement.Infrastructure.Managers;
using UserManagement.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.DataLayer.Repositories;

namespace NextDoor.Config
{
    public class MiddlewareConfiguration
    {

        public static void ConfigureEf(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

           
        }
        public static void ConfigureUow(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigureManager(IServiceCollection services)
        {

            services.AddScoped<ICategoriesManager,CategoriesManager>();
            services.AddScoped<IListingCategoriesManager, ListingCategoriesManager>();
            services.AddScoped<IEventCategoriesManager, EventCategoriesManager>();
            services.AddScoped<INextDoorUserManager, NextDoorUserManager>();




        }
        public static void ConfigureRepository(IServiceCollection services)
        {

            services.AddScoped<ICategoriesRepository,CategoriesRepository>();
            services.AddScoped<IListingCategoriesRepository, ListingCategoriesRepository>();
            services.AddScoped<IEventCategoriesRepository, EventCategoriesRepository>();
            services.AddScoped<INextDoorUserRepository, NextDoorUserRepository>();

       
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
