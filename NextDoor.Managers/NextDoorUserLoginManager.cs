using Microsoft.AspNetCore.Http;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.NextDoorUser;
using UserManagement.Infrastructure.Repositories;

namespace NextDoor.Managers
{
    public class NextDoorUserLoginManager : INextDoorUserLoginManager
    {
        private readonly INextDoorUserLoginReository _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public NextDoorUserLoginManager(IHttpContextAccessor contextAccessor,
          INextDoorUserLoginReository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;


        }


        public async Task<NextDoorUserDto> isExist(int userid)
        {
            try
            {
                return await _repository.isExist(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
