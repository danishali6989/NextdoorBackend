using Microsoft.AspNetCore.Http;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.MasterCre;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class MasterCredentialManager : IMasterCredentialManager
    {
        private readonly IMasterCredentialRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public MasterCredentialManager(IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork, IMasterCredentialRepository repository)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddMasterModel model)
        {
            await _repository.AddAsync(MasterCredentialFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
