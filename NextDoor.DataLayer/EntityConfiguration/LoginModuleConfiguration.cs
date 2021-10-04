using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    public class LoginModuleConfiguration : IEntityTypeConfiguration<LoginModule>
    {
        public void Configure(EntityTypeBuilder<LoginModule> builder)
        {
            {

                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.UserId).IsRequired();
                builder.Property(x => x.createdOn).IsRequired(false);
                builder.Property(x => x.status1).IsRequired(false);
                builder.Property(x => x.Status).IsRequired();
               
                builder.Property(x => x.LastLogin).IsRequired(false);

                
            }
        }
    }
}
