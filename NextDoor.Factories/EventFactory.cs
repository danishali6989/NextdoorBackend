using NextDoor.Entities;
using NextDoor.Models.Event;
using NextDoor.Models.Post;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class EventFactory
    {

        public static Event CreateEvent(EventAddModel model, string userId)
        {
            var data = new Event
            {
                User_ID = model.User_id,
                EventCategoryId = model.EventCategory_id,
                Title = model.Title,
                EventBookmark = false,
                Description = model.Description == null ? "" : model.Description,
                StartDate = model.StartDate == null ? "" : model.StartDate,
                StartTime = model.StartTime == null ? "" : model.StartTime,
                EndDate = model.EndDate == null ? "" : model.EndDate,
                EndTime = model.EndTime == null ? "" : model.EndTime,
                Address = model.Address == null ? "" : model.Address,
                Attachmentfile = model.FileUrl == null ||model.FileUrl =="string" ? "" : model.FileUrl,
                EventFileData = model.image,
                EventTimestamp = model.TimeStamp == null ? "" : model.TimeStamp,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                Status = Constants.RecordStatus.Active,
            };

            return data;
        }

        public static void CreateCount(SharePostAddModel model, Event entity, string userId)
        {
            entity.EventShareCount = entity.EventShareCount + 1;
        }

        public static ImageCollection CreateImage(AddImageModel model, string userId)
        {


            var data = new ImageCollection
            {
                Atachments = model.FileUrl,
                AtachmentType = model.MediaType,
                CreatedOn = Utility.GetDateTime(),
                Status = Constants.RecordStatus.Active,
            };

            return data;
        }

        public static void CreateEditEvent(EventAddModel model, Event entity,string userId)
        {

            entity.EventCategoryId = model.EventCategory_id;
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.StartDate = model.StartDate;
            entity.StartTime = model.StartTime;
            entity.EndDate = model.EndDate;
            entity.EndTime = model.EndTime;
            entity.Address = model.Address;
            entity.EventFileData = model.image;
            entity.EventTimestamp = model.TimeStamp == null ? "" : model.TimeStamp;
            if(model.FileUrl == "string")
            {
                if(entity.Attachmentfile == "")
                {
                   entity.Attachmentfile = "";
                }
                else
                {
                    entity.Attachmentfile = entity.Attachmentfile;
                }
            }
            else
            {
              entity.Attachmentfile = model.FileUrl;
            }

            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }
    }
}
