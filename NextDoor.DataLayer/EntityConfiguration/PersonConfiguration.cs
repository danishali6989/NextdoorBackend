using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.U_Id).IsRequired();
            builder.Property(x => x.P_Id).IsRequired();
            builder.Property(x => x.Hair).IsRequired();
            builder.Property(x => x.Top).IsRequired();
            builder.Property(x => x.Shoes).IsRequired();
            builder.Property(x => x.Bottom).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Build).IsRequired();
            builder.Property(x => x.Ethinicity).IsRequired();
            builder.Property(x => x.Sex).IsRequired();
            builder.Property(x => x.OtherDetails).IsRequired();

        }
    }
}
