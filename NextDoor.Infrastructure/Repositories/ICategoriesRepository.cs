using NextDoor.Dtos.Categories;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace NextDoor.Infrastructure.Repositories
{
    public interface ICategoriesRepository
    {
        Task AddAsync(Categories entity);
        void Edit(Categories entity);
        Task<Categories> GetAsync(int id);
        Task<CategoriesDetailDto> GetDetailAsync(int id);
        Task DeleteAsync(int id);
        Task<List<CategoriesDetailDto>> GetAllAsync();
    }
}
