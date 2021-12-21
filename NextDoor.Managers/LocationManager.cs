using Microsoft.AspNetCore.Http;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Location;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class LocationManager : ILocationManager
    {
        private readonly ILocationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public LocationManager(IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork, ILocationRepository repository)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddLocationModel model)
        {
            await _repository.AddAsync(LocationFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
