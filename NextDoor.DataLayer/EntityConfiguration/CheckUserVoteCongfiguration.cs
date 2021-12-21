using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class CheckUserVoteCongfiguration : IEntityTypeConfiguration<CheckUserVote>
    {
        public void Configure(EntityTypeBuilder<CheckUserVote> builder)
        {

            builder.ToTable("CheckUserVote");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Property(x => x.User_Id).IsRequired();
            builder.Property(x => x.Poll_Id).IsRequired();
            builder.Property(x => x.Response_Id).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();

        }
    }
}
