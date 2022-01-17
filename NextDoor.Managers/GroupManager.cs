using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Group;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Group;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class GroupManager: IGroupManager
    {
        private readonly IGroupRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public GroupManager(IHttpContextAccessor contextAccessor, IGroupRepository repository, IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(GroupAddModel model)
        {
            await _repository.AddGroupAsync(GroupFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(GroupEditModel model)
        {
            var item = await _repository.GetAsync(model.id);
            GroupFactory.Create(model,item,_userId);
           
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<GroupDetailDto>> GetAllAsync()
        {
           return await _repository.getallgroup();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.deletegroup(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
