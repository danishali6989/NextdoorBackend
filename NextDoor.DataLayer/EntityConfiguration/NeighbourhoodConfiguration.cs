using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class NeighbourhoodConfiguration : IEntityTypeConfiguration<Neighbourhood>
    {

        public void Configure(EntityTypeBuilder<Neighbourhood> builder)
        {
            builder.ToTable("Neighbourhood");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Userid).IsRequired();
            builder.Property(x => x.NeighbourhoodName).IsRequired();
            builder.Property(x => x.Postalcode).IsRequired();
            builder.Property(x => x.NeighbourhoodTimeStamp).IsRequired(false);

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
        }
    }
}
