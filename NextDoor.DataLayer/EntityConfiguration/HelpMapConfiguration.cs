using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class HelpMapConfiguration : IEntityTypeConfiguration<HelpMap>
    {
        public void Configure(EntityTypeBuilder<HelpMap> builder)
        {
            builder.ToTable("HelpMap");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.lat).IsRequired();
            builder.Property(x => x.lng).IsRequired();
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.ParentMessageId).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);


        }
    }
}
