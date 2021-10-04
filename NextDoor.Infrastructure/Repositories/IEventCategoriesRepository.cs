using NextDoor.Dtos.EventCategories;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IEventCategoriesRepository
    {
        Task AddAsync(EventCategories entity);
        void Edit(EventCategories entity);
        Task<EventCategories> GetAsync(int id);
        Task<EventCategoriesDetailDto> GetDetailAsync(int id);
        Task DeleteAsync(int id);
        Task<List<EventCategoriesDetailDto>> GetAllAsync();
    }
}
