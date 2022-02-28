using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Categories;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Categories;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class CategoriesManager: ICategoriesManager
    {
        private readonly ICategoriesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;
        public CategoriesManager(IHttpContextAccessor contextAccessor,
          ICategoriesRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;

        }
        public async Task AddAsync(CategoriesAddModel model)
        {
            await _repository.AddAsync(CategoriesFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(CategoriesAddModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            CategoriesFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<CategoriesDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<CategoriesDetailDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
