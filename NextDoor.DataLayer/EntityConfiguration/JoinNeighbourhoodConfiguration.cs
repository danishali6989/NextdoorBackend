using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    public class JoinNeighbourhoodConfiguration : IEntityTypeConfiguration<JoinNeighbourhood>
    {
        public void Configure(EntityTypeBuilder<JoinNeighbourhood> builder)
        {
            builder.ToTable("JoinNeighbourhood");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NeighbourhoodId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.TimeStamp).IsRequired(false);

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
            builder.HasOne(x => x.Neighbourhood).WithMany().HasForeignKey(x => x.NeighbourhoodId);
        }

    }
}
