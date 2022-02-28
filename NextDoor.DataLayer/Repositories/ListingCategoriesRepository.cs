using NextDoor.Dtos.ListingCategories;
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
    public  class ListingCategoriesRepository : IListingCategoriesRepository
    {
        private readonly DataContext _dataContext;
        public ListingCategoriesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(ListingCategories entity)
        {
            await _dataContext.ListingCategories.AddAsync(entity);
        }

        public void Edit(ListingCategories entity)
        {
            _dataContext.ListingCategories.Update(entity);
        }
        public async Task<ListingCategories> GetAsync(int id)
        {
            return await _dataContext.ListingCategories.FindAsync(id);
        }

        public async Task<ListingCategoriesDetailDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.ListingCategories
                          where s.ListingCategoryId == id
                          select new ListingCategoriesDetailDto
                          {
                              Id = s.ListingCategoryId,
                              ListingCategoryName = s.ListingCategoryName,
                              Status = s.Status
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.ListingCategories.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.ListingCategories.Update(data);
        }

        public async Task<List<ListingCategoriesDetailDto>> GetAllAsync()
        {
            return await (from s in _dataContext.ListingCategories
                          select new ListingCategoriesDetailDto
                          {
                              Id = s.ListingCategoryId,
                              ListingCategoryName = s.ListingCategoryName,
                              Status = s.Status
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

    }
}
