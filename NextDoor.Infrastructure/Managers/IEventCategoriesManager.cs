using NextDoor.Dtos.EventCategories;
using NextDoor.Models.EventCategories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IEventCategoriesManager
    {
        Task AddAsync(EventCategoriesAddModel model);
        Task EditAsync(EventCategoriesAddModel model);
        Task<EventCategoriesDetailDto> GetDetailAsync(int id);
        Task DeleteAsync(int id);
        Task<List<EventCategoriesDetailDto>> GetAllAsync();
    }
}
