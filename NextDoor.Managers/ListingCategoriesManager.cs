using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.ListingCategories;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.ListingCategories;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class ListingCategoriesManager : IListingCategoriesManager
    {

        private readonly IListingCategoriesRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public ListingCategoriesManager(IHttpContextAccessor contextAccessor,
          IListingCategoriesRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;



        }
        public async Task AddAsync(ListingCategoriesAddModel model)
        {
            await _repository.AddAsync(ListingCategoriesFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(ListingCategoriesAddModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            ListingCategoriesFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ListingCategoriesDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<ListingCategoriesDetailDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

    }
}
