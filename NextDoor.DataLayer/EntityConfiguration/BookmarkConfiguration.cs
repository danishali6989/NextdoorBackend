using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {

        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.ToTable("Bookmark");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).ValueGeneratedOnAdd();

            builder.Property(x => x.Post_id).IsRequired();
            builder.Property(x => x.USerId).IsRequired();
            builder.Property(x => x.Event_id).IsRequired();
            builder.Property(x => x.Poll_id).IsRequired();
            builder.Property(x => x.Category_id).IsRequired();
            builder.Property(x => x.EventCategory_id).IsRequired();
            builder.Property(x => x.Listingcategory_id).IsRequired();
            builder.Property(x => x.BookmarkTimeStamp).IsRequired(false);

            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
        }
    }
}
