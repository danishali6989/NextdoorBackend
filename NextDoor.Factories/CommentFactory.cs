using NextDoor.Entities;
using NextDoor.Models.Comment;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public  class CommentFactory
    {
        public static Comment CreateComment(CommentAddModel model, string userId)
        {
            var data = new Comment
            {
                CommentParent_Id = model.Comment_Parent_Id,
                User_id          = model.User_Id,
                Post_id          = model.PostId  != 0 ? model.PostId : 0,
                Event_id         = model.EventId != 0 ? model.EventId : 0,
                CommentText      = model.CommentText == null ? "" : model.CommentText,
                lat              = model.Lat,
                lng              = model.Lan,
                Attachment1      = model.FileUrl1   == null || model.FileUrl1   == "string" ? "" : model.FileUrl1,
                Attachment2      = model.FileUrl2   == null || model.FileUrl2   == "string" ? "" : model.FileUrl2,
                Attachment3      = model.FileUrl3   == null || model.FileUrl3   == "string" ? "" : model.FileUrl3,
                AttachmentType1  = model.MediaType1 == null || model.MediaType1 == "string" ? "" : model.MediaType1,
                AttachmentType2  = model.MediaType2 == null || model.MediaType2 == "string" ? "" : model.MediaType2,
                AttachmentType3  = model.MediaType3 == null || model.MediaType3 == "string" ? "" : model.MediaType3,

                Status           = Constants.RecordStatus.Active,
                CreatedBy        = userId ?? "0",
                CreatedOn        = Utility.GetDateTime(),


            };
            return data;
        }

        public static void EditComment(CommentEditModel model, Comment entity, string userId)
        {
            entity.CommentParent_Id = model.Comment_Parent_Id == null ? model.Comment_Parent_Id = 0 : model.Comment_Parent_Id;
            entity.User_id = model.User_Id;
            entity.Post_id = model.PostId != 0 ? model.PostId : 0;
            entity.Event_id = model.EventId != 0 ? model.EventId : 0;
            entity.CommentText = model.CommentText;
           
            if (entity.Attachment1 == "" )
            {
                if (model.FileUrl1 == null)
                {
                    entity.Attachment1 = "";
                }
                else if (model.FileUrl1 == "string")
                {
                    entity.Attachment1 = "";
                }
                else
                {
                  entity.Attachment1 = model.FileUrl1;
                }

            }
            else //if (entity.Attachment1 != "" )
            {
                if(model.FileUrl1 == null)
                {
                    entity.Attachment1 = entity.Attachment1;
                }
                else if (model.FileUrl1 == "string")
                {
                    entity.Attachment1 = entity.Attachment1;
                }
                else
                {
                    entity.Attachment1 = model.FileUrl1;
                }
               
            }



            if (entity.Attachment2 == "")
            {
                if (model.FileUrl2 == null)
                {
                    entity.Attachment2 = "";
                }
                else if (model.FileUrl2 == "string")
                {
                    entity.Attachment2 = "";
                }
                else
                {
                    entity.Attachment2 = model.FileUrl2;
                }

            }
            else //if (entity.Attachment2 != "" )
            {
                if (model.FileUrl2 == null)
                {
                    entity.Attachment2 = entity.Attachment2;
                }
                else if (model.FileUrl2 == "string")
                {
                    entity.Attachment2 = entity.Attachment2;
                }
                else
                {
                    entity.Attachment2 = model.FileUrl2;
                }

            }


            if (entity.Attachment3 == "")
            {
                if (model.FileUrl3 == null)
                {
                    entity.Attachment3 = "";
                }
                else if (model.FileUrl3 == "string")
                {
                    entity.Attachment3 = "";
                }
                else
                {
                    entity.Attachment3 = model.FileUrl1;
                }

            }
            else //if (entity.Attachment1 != "" )
            {
                if (model.FileUrl3 == null)
                {
                    entity.Attachment3 = entity.Attachment3;
                }
                else if (model.FileUrl3 == "string")
                {
                    entity.Attachment3 = entity.Attachment3;
                }
                else
                {
                    entity.Attachment3 = model.FileUrl3;
                }

            }




            entity.AttachmentType1 = model.MediaType1 == null || model.MediaType1 == "string" ? "" : model.MediaType1;
            entity.AttachmentType2 = model.MediaType2 == null || model.MediaType2 == "string" ? "" : model.MediaType2;
            entity.AttachmentType3 = model.MediaType3 == null || model.MediaType3 == "string" ? "" : model.MediaType3;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();

        }
    }
}
