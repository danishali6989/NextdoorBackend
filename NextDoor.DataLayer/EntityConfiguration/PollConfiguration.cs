using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class PollConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {

            builder.ToTable("Poll");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.PollBookmark).IsRequired(false);
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.Question).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.PollTimeStamp).IsRequired(false);
            
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
        }

    }
}
