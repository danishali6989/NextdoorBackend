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
        public DbSet<Post> Post { get; set; }
        public DbSet<Poll> Poll { get; set; }
        public DbSet<Multimedia> Multimedia { get; set; }
        public DbSet<PollMultimedia> PollMultimedia { get; set; }
        public DbSet<VechileSafety> VechileSafetty { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PolResponse> PolResponse { get; set; }
        public DbSet<PolOption> PolOption { get; set; }
        
        public DbSet<Event> Event { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
        public DbSet<ImageCollection> ImageCollection { get; set; }
        public DbSet<CheckUserVote> CheckUserVote { get; set; }

        public DbSet<Neighbourhood> Neighbourhood { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<MasterCredential> MasterCredential { get; set; }
        public DbSet<JoinNeighbourhood> JoinNeighbourhood { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<JoinGroup> JoinGroup { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new LoginModuleConfiguration());
            modelBuilder.ApplyConfiguration(new NextDoorUserConfiguration());
            modelBuilder.ApplyConfiguration(new EventCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new ListingCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new MultimediaConfiguration());
            modelBuilder.ApplyConfiguration(new VechileSafetyConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PollMultimediaConfiguration());
            modelBuilder.ApplyConfiguration(new PollConfiguration());
           
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new PolResponseConfiguration());
            modelBuilder.ApplyConfiguration(new PolOptionConfiguration());
            modelBuilder.ApplyConfiguration(new ImageCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new LikesConfiguration());
            modelBuilder.ApplyConfiguration(new BookmarkConfiguration());
            modelBuilder.ApplyConfiguration(new CheckUserVoteCongfiguration());
            modelBuilder.ApplyConfiguration(new NeighbourhoodConfiguration());
            modelBuilder.ApplyConfiguration(new MasterCredentialConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new JoinNeighbourhoodConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new JoinGroupConfiguration());

            modelBuilder.Entity<Post>()
            .HasOne(p => p.ListingCategories)
            .WithMany().HasForeignKey(x => x.ListingCategoryId); ;

            modelBuilder.Entity<Post>()
            .HasOne(p => p.NextDoorUser)
            .WithMany().HasForeignKey(x => x.User_id); ;

            modelBuilder.Entity<Post>()
           .HasOne(p => p.Categories)
           .WithMany().HasForeignKey(x => x.Category_id); ;

            modelBuilder.Entity<Event>()
           .HasOne(p => p.EventCategories)
           .WithMany().HasForeignKey(x => x.EventCategoryId); ;

            modelBuilder.Entity<Event>()
          .HasOne(p => p.NextDoorUser)
          .WithMany().HasForeignKey(x => x.User_ID); ;

            modelBuilder.Entity<Poll>()
         .HasOne(p => p.NextDoorUser)
         .WithMany().HasForeignKey(x => x.UserID); ;

            modelBuilder.Entity<Comment>()
         .HasOne(p => p.NextDoorUser)
         .WithMany().HasForeignKey(x => x.User_id); ;

        }
    }
}
