using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class PolOptionConfiguration : IEntityTypeConfiguration<PolOption>
    {
       public void Configure(EntityTypeBuilder<PolOption> builder)
      {

        builder.ToTable("PollOptions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();


        builder.Property(x => x.User_id).IsRequired();
        builder.Property(x => x.Poll_id).IsRequired();
        builder.Property(x => x.Option_Name).IsRequired(false);
        builder.Property(x => x.Count).IsRequired();
        builder.Property(x => x.Count_total).IsRequired(false);
        builder.Property(x => x.Percentage_Count).IsRequired(false);
        builder.Property(x => x.CreatedOn).IsRequired();

       }
   }
}

