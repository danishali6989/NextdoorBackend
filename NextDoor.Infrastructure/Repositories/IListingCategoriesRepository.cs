using NextDoor.Dtos.ListingCategories;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IListingCategoriesRepository
    {
        Task AddAsync(ListingCategories entity);
        void Edit(ListingCategories entity);
        Task<ListingCategories> GetAsync(int id);
        Task<ListingCategoriesDetailDto> GetDetailAsync(int id);
        Task DeleteAsync(int id);
        Task<List<ListingCategoriesDetailDto>> GetAllAsync();
    }
}
