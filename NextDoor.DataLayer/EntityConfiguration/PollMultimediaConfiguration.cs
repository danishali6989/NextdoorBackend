using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class PollMultimediaConfiguration : IEntityTypeConfiguration<PollMultimedia>
    {
        public void Configure(EntityTypeBuilder<PollMultimedia> builder)
        {

            builder.ToTable("PollMultimedia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Polld).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CategoryID).IsRequired();
            builder.Property(x => x.Atachments).IsRequired();
            builder.Property(x => x.AtachmentType).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
