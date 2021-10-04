using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Categories;
using NextDoor.Dtos.EventCategories;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.EventCategories;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class EventCategoriesManager : IEventCategoriesManager
    {
        private readonly IEventCategoriesRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public EventCategoriesManager(IHttpContextAccessor contextAccessor,
          IEventCategoriesRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;



        }
        public async Task AddAsync(EventCategoriesAddModel model)
        {
            await _repository.AddAsync(EventCategoriesFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(EventCategoriesAddModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            EventCategoriesFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<EventCategoriesDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<EventCategoriesDetailDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
