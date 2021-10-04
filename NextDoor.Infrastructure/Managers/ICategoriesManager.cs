using NextDoor.Dtos.Categories;
using NextDoor.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface ICategoriesManager
    {
        Task AddAsync(CategoriesAddModel model);
        Task EditAsync(CategoriesAddModel model);
        Task<CategoriesDetailDto> GetDetailAsync(int id);
        Task DeleteAsync(int id);
        Task<List<CategoriesDetailDto>> GetAllAsync();
    }
}
