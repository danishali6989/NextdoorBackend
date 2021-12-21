using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    public class ListingCategoriesConfiguration : IEntityTypeConfiguration<ListingCategories>
    {
        public void Configure(EntityTypeBuilder<ListingCategories> builder)
        {
            builder.ToTable("ListingCategories");

            builder.HasKey(x => x.ListingCategoryId);

            builder.Property(x => x.ListingCategoryId).ValueGeneratedOnAdd();

            builder.Property(x => x.ListingCategoryName).IsRequired();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);




            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);


        }
    }
}
