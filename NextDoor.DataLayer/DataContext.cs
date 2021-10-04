using System;
using System.Collections.Generic;
using System.Text;
using NextDoor.DataLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextDoor.Entities;
using NextDoor.DataLayer.EntityConfiguration;

namespace NextDoor.DataLayer
{
    public  class DataContext : IdentityDbContext<AppUser>
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ListingCategories> ListingCategories { get; set; }
        public DbSet<EventCategories> EventCategories { get; set; }
        public DbSet<LoginModule> LoginModule { get; set; }

        public DbSet<NextDoorUser> NextDoorUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new LoginModuleConfiguration());
            modelBuilder.ApplyConfiguration(new NextDoorUserConfiguration());
            modelBuilder.ApplyConfiguration(new EventCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new ListingCategoriesConfiguration());
        }
    }
}
