using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class EventCategoriesConfiguration : IEntityTypeConfiguration<EventCategories>
    {
        public void Configure(EntityTypeBuilder<EventCategories> builder)
        {
            builder.ToTable("EventCategories");

            builder.HasKey(x => x.EventCategory_Id);

            builder.Property(x => x.EventCategory_Id).ValueGeneratedOnAdd();

            builder.Property(x => x.EventCategoryName).IsRequired();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);




            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);


        }
    }
}
