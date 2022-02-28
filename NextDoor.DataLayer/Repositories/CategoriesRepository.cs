using NextDoor.Dtos.Categories;
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
    public class CategoriesRepository: ICategoriesRepository
    {

        private readonly DataContext _dataContext;
        public CategoriesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Categories entity)
        {
            await _dataContext.Categories.AddAsync(entity);
        }

        public void Edit(Categories entity)
        {
            _dataContext.Categories.Update(entity);
        }
        public async Task<Categories> GetAsync(int id)
        {
            return await _dataContext.Categories.FindAsync(id);
        }

        public async Task<CategoriesDetailDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.Categories
                          where s.Id == id
                          select new CategoriesDetailDto
                          {
                              Id = s.Id,
                              CategoryName = s.CategoryName,
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

        public async Task<List<CategoriesDetailDto>> GetAllAsync()
        {
            return await (from s in _dataContext.Categories

                          select new CategoriesDetailDto
                          {
                              Id = s.Id,
                              CategoryName = s.CategoryName,
                             
                              Status = s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
    }
}
