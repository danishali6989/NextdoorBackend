using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using NextDoor.Dtos.EventCategories;
using Microsoft.EntityFrameworkCore;

namespace NextDoor.DataLayer.Repositories
{
    public class EventCategoriesRepository : IEventCategoriesRepository
    {

        private readonly DataContext _dataContext;

        public EventCategoriesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(EventCategories entity)
        {
            await _dataContext.EventCategories.AddAsync(entity);
        }

        public void Edit(EventCategories entity)
        {
            _dataContext.EventCategories.Update(entity);
        }
        public async Task<EventCategories> GetAsync(int id)
        {
            return await _dataContext.EventCategories.FindAsync(id);
        }

        public async Task<EventCategoriesDetailDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.EventCategories
                          where s.Id == id
                          select new EventCategoriesDetailDto
                          {
                              Id = s.Id,
                              EventCategoryName = s.EventCategoryName,
                              Status = s.Status

                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.Categories.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Categories.Update(data);
        }

        public async Task<List<EventCategoriesDetailDto>> GetAllAsync()
        {
            return await (from s in _dataContext.EventCategories

                          select new EventCategoriesDetailDto
                          {
                              Id = s.Id,
                              EventCategoryName = s.EventCategoryName,

                              Status = s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
    }
}
