using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class MasterCredentialConfiguration : IEntityTypeConfiguration<MasterCredential>
    {

        public void Configure(EntityTypeBuilder<MasterCredential> builder)
        {
            builder.ToTable("MasterCredential");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Origin).IsRequired();
            builder.Property(x => x.Server).IsRequired();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);

            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);


        }
    }

}
