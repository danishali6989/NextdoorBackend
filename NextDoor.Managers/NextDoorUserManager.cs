using Microsoft.AspNetCore.Http;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Models.NextDoorUser;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.NextDoorUser;
using UserManagement.Factories;

using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;


namespace UserManagement.Managers
{
   public class NextDoorUserManager : INextDoorUserManager
    {
        private readonly INextDoorUserRepository _repository;
        
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public NextDoorUserManager(IHttpContextAccessor contextAccessor,
          INextDoorUserRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
           

        }


        public async Task AddAsync(AddNextDoorUserModel model,string header)
        {
            await _repository.AddAsync(NextDoorUserFactory.Create(model, _userId,header));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<NextDoorUserDto> CheckNextDoorUserEmail(string Email)
        {
            return await _repository.GetByUserEmailAsync(Email);
        }

        public async Task<NextDoorUserDto> CheckNextDoorUser(int userid)
        {
            return await _repository.GetByUseridAsync(userid);
        }
        public async Task<NextDoorUserDto> getuser(string username)
        {
            return await _repository.getuserdetail(username);
        }

        public async Task EditAsync(EditNextDoorUser model)
        {
            var item = await _repository.GetAsync(model.UserId);
            NextDoorUserFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

      
        public async Task<List<NextDoorUserDto>> GetUserList(string PostalCode)
        {
            return await _repository.GetUserList(PostalCode);
        }

    }
}
