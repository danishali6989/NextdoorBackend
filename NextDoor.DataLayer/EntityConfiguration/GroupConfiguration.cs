using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.GroupName).IsRequired();
            builder.Property(x => x.GroupTimeStamp).IsRequired(false);

            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.GroupTimeStamp).IsRequired(false);

            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);

        }
    }
}