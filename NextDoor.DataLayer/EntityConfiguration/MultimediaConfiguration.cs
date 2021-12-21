using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class MultimediaConfiguration : IEntityTypeConfiguration<Multimedia>
    {

        public void Configure(EntityTypeBuilder<Multimedia> builder)
        {

            builder.ToTable("Multimedia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x=>x.UserId).IsRequired();
            builder.Property(x => x.CategoryiD).IsRequired();
            builder.Property(x => x.Atachments).IsRequired();
            builder.Property(x => x.AtachmentType).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
