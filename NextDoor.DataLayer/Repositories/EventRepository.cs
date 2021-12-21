using NextDoor.Dtos.Event;
using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using NextDoor.Utilities;

namespace NextDoor.DataLayer.Repositories
{
   public class EventRepository : IEventRepository
    {

        private readonly DataContext _dataContext;

        public EventRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Edit(Event entity)
        {
            _dataContext.Event.Update(entity);
        }

        public async Task DeleteEvent(int eventid)
        {
            var data = await _dataContext.Event.FindAsync(eventid);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Event.Update(data);
        }
        public async Task AddEventAsync(Event entity)
        {
            await _dataContext.Event.AddAsync(entity);
        }
        public async Task<Event> geteventdetail(int eventid)
        {
            return await _dataContext.Event.FindAsync(eventid);
        }
        public async Task AddImageAsync(ImageCollection entity)
        {
            await _dataContext.ImageCollection.AddAsync(entity);
        }

        public async Task<List<ImageDetailDto>> ImageGetAllAsync()
        {
            return await (from s in _dataContext.ImageCollection

                          select new ImageDetailDto
                          {
                              id = s.Id,
                              Atachments = s.Atachments,
                              AtachmentType= s.AtachmentType,
                              CreatedOn = s.CreatedOn,

                              Status = s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<EventDetailDto>> geteventbyeventid(int eventid)
        {
            return await (from s in _dataContext.Event


                          where s.ID == eventid

                          select new EventDetailDto
                          {
                              ID = s.ID,
                              EventCategory_Id = s.EventCategoryId,
                              EventCategoryName = s.EventCategories.EventCategoryName,
                              User_ID = s.User_ID,
                              Title = s.Title,
                              Description = s.Description,
                              Attachmentfile = s.Attachmentfile,
                              Address = s.Address,
                              StartDate = s.StartDate,
                              StartTime = s.StartTime,
                              EndDate = s.EndDate,
                              EndTime = s.EndTime,

                              CreatedOn = s.CreatedOn,

                              Status = s.Status


                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<List<EventDetailDto>> EventGetAllAsync()
        {
            return await (from s in _dataContext.Event

                          select new EventDetailDto
                          {
                              ID = s.ID,
                              EventCategory_Id = s.EventCategoryId,
                              EventCategoryName = s.EventCategories.EventCategoryName,
                              EventBookmark = s.EventBookmark,
                              User_ID = s.User_ID,
                              Title = s.Title,
                              Description = s.Description,
                              Attachmentfile = s.Attachmentfile,
                              Address = s.Address,
                              StartDate = s.StartDate,
                              StartTime = s.StartTime,
                              EndDate = s.EndDate,
                              EndTime = s.EndTime,
                             
                              CreatedOn = s.CreatedOn,

                              Status = s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<EventComment>> getEventCommentByid(int Id)
        {
            return await (from s in _dataContext.Comment
                          where s.Event_id == Id && s.CommentParent_Id == 0

                          select new EventComment
                          {
                              id = s.Id,
                              User_id = s.User_id,
                              Eventid = s.Event_id,
                              CommentParent_Id = s.CommentParent_Id,
                              CommentText = s.CommentText,
                              Attachment1 = s.Attachment1,
                              Attachment2 = s.Attachment2,
                              Attachment3 = s.Attachment3,
                              lat = s.lat,
                              lng = s.lng,




                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<List<EventLikes>> getEventlikesById(int Id)
        {
            return await (from s in _dataContext.Likes
                          where s.Event_id == Id && s.Comment_id == 0

                          select new EventLikes
                          {
                              Comment_id = s.Comment_id,
                              Reaction_Id = s.Reaction_Id,
                              User_id = s.User_id,




                          })
                          .AsNoTracking()
                          .ToListAsync();
        }


        public Constants.ReactionStatus getEventLikesReactionById(int userid,int eventid)
        {

            var obj = _dataContext.Likes.Where(x => x.User_id == userid && x.Event_id == eventid && x.Comment_id == 0).FirstOrDefault();
            if (obj == null)
            {
                return 0;
            }
            else
            {
              return obj.Reaction_Id;

            }

        }
    }
}
