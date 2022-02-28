using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    public class ShareDetailConfiguration : IEntityTypeConfiguration<ShareDetail>
    {
        public void Configure(EntityTypeBuilder<ShareDetail> builder)
        {
            builder.ToTable("ShareDetail");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.EventId).IsRequired();
            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x => x.PollId).IsRequired();
            builder.Property(x => x.Userid).IsRequired();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
        }
    }
}
