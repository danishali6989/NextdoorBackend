using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class VechileSafetyConfiguration : IEntityTypeConfiguration<VechileSafety>
    {

        public void Configure(EntityTypeBuilder<VechileSafety> builder)
        {
            builder.ToTable("VechileSafety");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Userid).IsRequired();
            builder.Property(x => x.Post_Id).IsRequired();
            builder.Property(x => x.Color).IsRequired();
            builder.Property(x => x.Make).IsRequired();
            builder.Property(x => x.Model).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.RegNo).IsRequired();
            builder.Property(x => x.Other_Details).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
           
        }
    }
}
