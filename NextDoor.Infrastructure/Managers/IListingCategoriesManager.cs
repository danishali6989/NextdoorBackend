using NextDoor.Dtos.ListingCategories;
using NextDoor.Models.ListingCategories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public  interface IListingCategoriesManager
    {
        Task AddAsync(ListingCategoriesAddModel model);
        Task EditAsync(ListingCategoriesAddModel model);
        Task<ListingCategoriesDetailDto> GetDetailAsync(int id);
        Task DeleteAsync(int id);
        Task<List<ListingCategoriesDetailDto>> GetAllAsync();
    }
}
