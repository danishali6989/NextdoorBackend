using NextDoor.Entities;
using NextDoor.Models.Post;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class PostFactory
    {

        public static Post Create(PostAddModel model, string userId)
        {


            var data = new Post
            {
                // CategoryName = model.CategoryName,
                User_id            = model.UserId,
                Category_id        = model.CategoryId,
                ListingCategoryId  = model.Listing_CategoryId == 0 ? 23 : model.Listing_CategoryId,
                Subject            = model.Subject,
                Message            = model.Message,
                lat                = (model.Lat == 0) ? 0 : model.Lat,
                lan                = (model.Lan == 0) ? 0 : model.Lan,
                Bookmark           = false,
                PostTimeStamp      = model.TimeStamp== null ?"":model.TimeStamp,
                Attachment         = "",
                Status             = Constants.RecordStatus.Active,
                CreatedBy          = userId ?? "0",
                CreatedOn          = Utility.GetDateTime(),


            };

                return data;
        }
        public static Post CreateFinds(PostAddModel model, string userId)
        {


            var data = new Post
            {
                // CategoryName = model.CategoryName,
                User_id           = model.UserId,
                Category_id       = model.CategoryId,
                ListingCategoryId = model.Listing_CategoryId == 0 ? 23 : model.Listing_CategoryId,
                Subject           = model.Subject,
                Message           = model.Message,
                lat               = (model.Lat == 0) ? 0 : model.Lat,
                lan               = (model.Lan == 0) ? 0 : model.Lan,
                PostTimeStamp     = model.TimeStamp==null?"":model.TimeStamp,
                Attachment        = "",
                Status            = Constants.RecordStatus.Active,
                CreatedBy         = userId ?? "0",
                CreatedOn         = Utility.GetDateTime(),


            };

            return data;
        }

        public static Post Create(PostFindsAddModel model, string userId)
        {


            var data = new Post
            {
               
                User_id            = model.UserId,
                Category_id        = model.CategoryId,
                ListingCategoryId = model.Listing_CategoryId == 0 ? 23 : model.Listing_CategoryId,
                Subject            = model.Subject,
                Message            = model.Message,
                lat                = (model.Lat == 0)             ? 0 : model.Lat,
                lan                = (model.Lan == 0)             ? 0 : model.Lan,
                PostTimeStamp      = model.TimeStamp == null ? "" :model.TimeStamp,
                Price              = (model.free == 1             ? 0 : (model.Price == 0 ? 0 : model.Price)),
                Attachment         = "",
                Status             = Constants.RecordStatus.Active,
                CreatedBy          = userId ?? "0",
                CreatedOn          = Utility.GetDateTime(),


            };

            return data;
        }

        public static Post Create(PostSafetyAddModel model, string userId)
        {


            var data = new Post
            {

                User_id                 = model.UserId,
                Category_id             = model.CategoryId,
                SafetyDescription       = model.SafetyDescription,
                SafetyPersonDescription = model.SafetyPersonDescription,
                Subject                 = model.Subject,
                Message                 = model.Message,
                lat                     = (model.Lat == 0) ? 0 : model.Lat,
                lan                     = (model.Lan == 0) ? 0 : model.Lan,
                ListingCategoryId       = 23,
                Attachment              = "",
                PostTimeStamp           = model.TimeStamp==null?"":model.TimeStamp,
                Status                  = Constants.RecordStatus.Active,
                CreatedBy               = userId ?? "0",
                CreatedOn               = Utility.GetDateTime(),


            };

            return data;
        }
        public static Multimedia CreateMultimedia(PostAddModel model, string userId)
        {


            var data = new Multimedia
            {
                PostId = model.Id,
                UserId = model.UserId,
                Atachments = model.FileUrl,
                AtachmentType = model.MediaType,
                CreatedOn = Utility.GetDateTime(),
                CategoryiD = model.CategoryId,
                FileData = model.FileData

            };

            return data;
        }


        public static Multimedia CreateMultimedia(PostEditModel model, string userId)
        {


            var data = new Multimedia
            {
                PostId        = model.Id,
                UserId        = model.UserId,
                Atachments    = model.FileUrl,
                AtachmentType = model.MediaType,
                CreatedOn     = Utility.GetDateTime(),
                CategoryiD    = model.CategoryId,
                FileData       = model.FileData,


            };

            return data;
        }

        public static Multimedia CreateMultimedia(PostFindsEditModel model, string userId)
        {


            var data = new Multimedia
            {
                PostId        = model.Id,
                UserId        = model.UserId,
                Atachments    = model.FileUrl,
                AtachmentType = model.MediaType,
                CreatedOn     = Utility.GetDateTime(),
                CategoryiD    = model.CategoryId,
                FileData      = model.FileData,
                

            };

            return data;
        }
        public static Multimedia CreateMultimedia(PostFindsAddModel model, string userId)
        {


            var data = new Multimedia
            {
                PostId        = model.Id,
                UserId        = model.UserId,
                Atachments    = model.FileUrl,
                AtachmentType = model.MediaType,
                CreatedOn     = Utility.GetDateTime(),
                CategoryiD    = model.CategoryId,
                FileData      = model.FileData,
            };

            return data;
        }
        public static Multimedia CreateMultimedia(PostSafetyAddModel model, string userId)
        {


            var data = new Multimedia
            {
                PostId        = model.Id,
                UserId        = model.UserId,
                Atachments    = model.FileUrl,
                AtachmentType = model.MediaType,
                CreatedOn     = Utility.GetDateTime(),
                CategoryiD    = model.CategoryId,
                FileData      = model.FileData,
            };

            return data;
        }

        public static Person CreatePerson(AddPersonModel model, string userId)
        {


            var data = new Person
            {
                // CategoryName = model.CategoryName,
                    
                    P_Id         =  model.Pid,
                    U_Id         =  model.userid,
                    Hair         =  model.Hair == null         ? "" : model.Hair,
                    Top          =  model.Top == null          ? "" : model.Top,
                    Bottom       =  model.Bottom == null       ? "" : model.Bottom,
                    Shoes        =  model.Shoes == null        ? "" : model.Shoes,
                    Age          =  model.Age == null          ? "" : model.Age,
                    Build        =  model.Build == null        ? "" : model.Build,
                    Ethinicity   =  model.Ethinicity == null   ? "" : model.Ethinicity,
                    Sex          =  model.Sex == null          ? "" : model.Sex,
                    OtherDetails =  model.OtherDetails == null ? "" : model.OtherDetails,
                    CreatedOn    =  Utility.GetDateTime(),


            };

            return data;
        }

        public static VechileSafety CreateVechile(AddVechileModel model, string userId)
        {


            var data = new VechileSafety
            {
                // CategoryName = model.CategoryName,

                Post_Id        = model.P_id,
                Userid         = model.User_id,
                Color          = model.Color == null          ? "" : model.Color,
                Make           = model.Make == null           ? "" : model.Make,
                Model          = model.Model == null          ? "" : model.Model,
                Year           = model.Year == null           ? "" : model.Year,
                Type           = model.Type == null           ? "" : model.Type,
                Other_Details  = model.Other_Details == null  ? "" : model.Other_Details,
                RegNo          = model.RegNo == null          ? "" : model.RegNo,
                CreatedOn      = Utility.GetDateTime(),


            };

            return data;
        }

        public static void CreateEditPost(PostEditModel model, Post entity, string userId)
        {
            entity.Subject           = model.Subject;
            entity.Message           = model.Message;
            entity.ListingCategoryId = model.Listing_CategoryId == 0 ? 23 : model.Listing_CategoryId;
            entity.Price             = (model.free == 1              ? 0  : (model.Price == 0 ? 0 : model.Price));
            entity.lat               = model.Lat;
            entity.lan               = model.Lan;
            entity.PostTimeStamp     = model.TimeStamp == null ? "" : model.TimeStamp;
            entity.UpdatedBy         = userId ?? "0";
            entity.UpdatedOn         = Utility.GetDateTime();

        }
        public static void CreateFindsEditPost(PostFindsEditModel model, Post entity, string userId)
        {
            entity.Subject           = model.Subject;
            entity.Message           = model.Message;
            entity.ListingCategoryId = model.Listing_CategoryId == 0 ? 23 : model.Listing_CategoryId;
            entity.Price             = (model.free == 1              ? 0  : (model.Price == 0 ? 0 : model.Price));
            entity.lat               = model.Lat;
            entity.lan               = model.Lan;
            entity.PostTimeStamp     = model.TimeStamp == null ? "" : model.TimeStamp;
            entity.UpdatedBy         = userId ?? "0";
            entity.UpdatedOn         = Utility.GetDateTime();

        }
        public static void CreateSafetyEditPost(PostSafetyAddModel model, Post entity, string userId)
        {
            entity.Subject                 = model.Subject;
            entity.Message                 = model.Message;
            entity.SafetyDescription       = model.SafetyDescription;
            entity.SafetyPersonDescription = model.SafetyPersonDescription;
            entity.lat                     = model.Lat;
            entity.lan                     = model.Lan;
            entity.PostTimeStamp           = model.TimeStamp == null ? "" :  model.TimeStamp;
            entity.UpdatedBy               = userId ?? "0";
            entity.UpdatedOn               = Utility.GetDateTime();

        }
    }
}
