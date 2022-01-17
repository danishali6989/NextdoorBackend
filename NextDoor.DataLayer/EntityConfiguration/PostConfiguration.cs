using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.User_id).IsRequired();
            builder.Property(x => x.Category_id).IsRequired();
            builder.Property(x => x.ListingCategoryId).IsRequired();
            builder.Property(x => x.Subject).IsRequired(); 
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.SafetyDescription).IsRequired(false);
            builder.Property(x => x.SafetyPersonDescription).IsRequired(false);
            builder.Property(x => x.Price).IsRequired(); 
            builder.Property(x => x.lat).IsRequired(); 
            builder.Property(x => x.lan).IsRequired();
            builder.Property(x => x.Attachment).IsRequired(false);
            builder.Property(x => x.PostTimeStamp).IsRequired(false);

            builder.Property(x => x.Bookmark).IsRequired(false);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
           // builder.HasOne(x => x.ListingCategories).WithMany().HasForeignKey(x => x.ListingCategoryId);

        }
    }
}
