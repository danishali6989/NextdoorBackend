using NextDoor.Dtos.Event;
using NextDoor.Models.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public  interface IEventManager
    {
        Task AddImageAsync(AddImageModel model);
        Task AddEventAsync(EventAddModel model);
        Task EventEditAsync(EventAddModel model);
        Task<List<ImageDetailDto>> ImageGetAllAsync();
        Task<List<EventDetailDto>> EventGetAllAsync(int userid);
        Task<List<EventDetailDto>> EventGetAllBookmarkAsync(int userid);
        Task<List<EventDetailDto>> EventGetAllAsync();
        Task DeleteEventAsync(int eventid);
        Task<List<EventDetailDto>> GetEventByEventId(int eventid);
    }
}
