using NextDoor.Dtos.Event;
using NextDoor.Entities;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IEventRepository
    {
        Task AddEventAsync(Event entity);
        void Edit(Event entity);
        Task DeleteEvent(int eventid);
        Task AddImageAsync(ImageCollection entity);
        Task<Event> geteventdetail(int eventid);
        Task AddShareUserDetailsAsync(ShareDetail entity);

        Task<List<ImageDetailDto>> ImageGetAllAsync();
        Task<List<EventDetailDto>> EventGetAllAsync();
        Task<List<EventDetailDto>> EventGetAllBookmarkAsync(int userid);
        Task<List<EventDetailDto>> geteventbyeventid(int eventid);
        Task<List<EventLikes>> getEventlikesById(int id);
         Constants.ReactionStatus getEventLikesReactionById(int userid,int eventid);
        Task<List<EventComment>> getEventCommentByid(int id);
    }
}
