using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.JoinNeighbourhood;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.JoinNeighbourhood;
using NextDoor.Models.Neigbourhood;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class JoinNeighbourhoodManager : IJoinNeighbourhoodManager
    {
        private readonly IJoinNeighbourhoodRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public JoinNeighbourhoodManager(IHttpContextAccessor contextAccessor, IJoinNeighbourhoodRepository repository,IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId(); ;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(JoinNeighbourhoodAddModel model) 
        {
            await _repository.AddAsync(JoinNeighbourhoodFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task JoinAsync(NeighbourhoodAddModel model)
        {
            await _repository.AddAsync(JoinNeighbourhoodFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<JoinNeighbourhoodDto> checkjoin(int userid)
        {
            return await _repository.checkuserjoin(userid);
        }
    }
}
