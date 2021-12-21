using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class PolResponseConfiguration : IEntityTypeConfiguration<PolResponse>
    {
        public void Configure(EntityTypeBuilder<PolResponse> builder)
        {

            builder.ToTable("PollResponse");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Property(x => x.User_Id).IsRequired();
            builder.Property(x => x.Poll_Id).IsRequired();
            builder.Property(x => x.OptionName).IsRequired();
            builder.Property(x => x.Count).IsRequired(false);
            builder.Property(x => x.TotalCount).IsRequired(false);
            builder.Property(x => x.PercentageCount).IsRequired(false);
            builder.Property(x => x.CreatedOn).IsRequired();
           
        }
    }
}
