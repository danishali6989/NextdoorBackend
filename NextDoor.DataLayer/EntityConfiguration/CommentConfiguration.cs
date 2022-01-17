using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CommentParent_Id).IsRequired();
            builder.Property(x => x.User_id).IsRequired();
            builder.Property(x => x.Post_id).IsRequired();
            builder.Property(x => x.Poll_id).IsRequired();
            builder.Property(x => x.Event_id).IsRequired();
            builder.Property(x => x.CommentText).IsRequired();
            builder.Property(x => x.lat).IsRequired();
            builder.Property(x => x.lng).IsRequired();
            builder.Property(x => x.Attachment1).IsRequired();
            builder.Property(x => x.Attachment2).IsRequired();
            builder.Property(x => x.Attachment3).IsRequired();
            builder.Property(x => x.AttachmentType1).IsRequired();
            builder.Property(x => x.AttachmentType2).IsRequired();
            builder.Property(x => x.AttachmentType3).IsRequired();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.TimeStamp).IsRequired(false);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);

            /*builder.HasOne(x => x.NextDoorUser).WithMany().HasForeignKey(x => x.User_id);
            builder.HasOne(x => x.Post).WithMany().HasForeignKey(x => x.Post_id);*/
        }
    }
}
