using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");
           
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            
            builder.Property(x => x.User_ID).IsRequired();
            builder.Property(x => x.EventCategoryId).IsRequired();
            builder.Property(x => x.Attachmentfile).IsRequired(false);
            builder.Property(x => x.EventFileData).IsRequired(false);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.StartTime).IsRequired(false);
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.EventBookmark).IsRequired(false);
            builder.Property(x => x.EventTimestamp).IsRequired(false);

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);

        }
    }
}
