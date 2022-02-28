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
            services.AddScoped<IPostManager,PostManager>();
            services.AddScoped<IPollManager, PollManager>();
            services.AddScoped<IEventManager, EventManager>();
            services.AddScoped<ICommentManager, CommentManager>();
            services.AddScoped<ILikeManager, LikeManager>();
            services.AddScoped<IBookmarkManager, BookmarkManager>();
            services.AddScoped<INextDoorUserLoginManager, NextDoorUserLoginManager>();
            services.AddScoped<INeighbourhoodManager,NeighbourhoodManager>();
            services.AddScoped<IMasterCredentialManager, MasterCredentialManager>();
            services.AddScoped<ILocationManager, LocationManager>();
            services.AddScoped<IJoinNeighbourhoodManager, JoinNeighbourhoodManager>();
            services.AddScoped<IGroupManager, GroupManager>();
            services.AddScoped<IJoinGroupManager, JoinGroupManager>();
            services.AddScoped<IHelpMapManager, HelpMapManager>();
            services.AddScoped<IBusinessTypeManager, BusinessTypeManager>();


        }
        public static void ConfigureRepository(IServiceCollection services)
        {

            services.AddScoped<ICategoriesRepository,CategoriesRepository>();
            services.AddScoped<IListingCategoriesRepository, ListingCategoriesRepository>();
            services.AddScoped<IEventCategoriesRepository, EventCategoriesRepository>();
            services.AddScoped<INextDoorUserRepository, NextDoorUserRepository>();
            services.AddScoped<IPostRepository,PostRepository>();
            services.AddScoped<IPollRepository, PollRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<INextDoorUserLoginReository, NextDoorUserLoginRepository>();
            services.AddScoped<INeighbourhoodRepository,NeighbourhoodRepository>();
            services.AddScoped<IMasterCredentialRepository, MasterCredentialRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IJoinNeighbourhoodRepository, JoinNeighbourhoodRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IJoinGroupRepository, JoinGroupRepository>();
            services.AddScoped<IHelpMapRepository, HelpMapRepository>();
            services.AddScoped<IBusinessTypeRepository, BusinessTypeRepository>();



        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
 