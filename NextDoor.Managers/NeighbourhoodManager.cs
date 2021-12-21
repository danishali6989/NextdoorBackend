using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Neighbourhood;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Location;
using NextDoor.Models.Neigbourhood;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class NeighbourhoodManager : INeighbourhoodManager
    {
        private readonly INeighbourhoodRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public NeighbourhoodManager(IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork,INeighbourhoodRepository repository)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(NeighbourhoodAddModel model)
        {
            await _repository.AddAsync(NeighbourhoodFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddLocation(AddLocationModel model)
        {
            await _repository.AddLocation(NeighbourhoodFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(NeighbourhoodAddModel model)
        {
            var item = await _repository.GetAsync(model.id);
            NeighbourhoodFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<NeighbourhoodDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }
        public async Task<NeighbourhoodDetailDto> GetDetail(int userid)
        {
            return await _repository.GetDetail(userid);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _repository.getlocation(id);
            foreach (var item in data)
            {
                await _repository.DeleteLocation(item.id);
            }
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<List<NeighbourhoodDetailDto>> GetAllAsync()
        {
           var data = await _repository.GetAllAsync();
            foreach (var item in data)
            {
                item.location = await _repository.getlocationbyuserid(item.userid);
            }
            return data;
        }
    }
}
