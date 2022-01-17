using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class JoinGroupConfiguration : IEntityTypeConfiguration<JoinGroup>
    {
        public void Configure(EntityTypeBuilder<JoinGroup> builder)
        {
            builder.ToTable("JoinGroup");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Groupid).IsRequired();
            builder.Property(x => x.USerid).IsRequired();
            builder.Property(x => x.GroupTimeStamp).IsRequired(false);

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
            builder.HasOne(x => x.Group).WithMany().HasForeignKey(x => x.Groupid);

        }
    }
}
