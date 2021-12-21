using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class ImageCollectionConfiguration : IEntityTypeConfiguration<ImageCollection>
    {
        public void Configure(EntityTypeBuilder<ImageCollection> builder)
        {

            builder.ToTable("ImageCollection");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

           
            builder.Property(x => x.Atachments).IsRequired();
            builder.Property(x => x.AtachmentType).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
