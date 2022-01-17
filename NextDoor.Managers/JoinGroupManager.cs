using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Group;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class JoinGroupManager : IJoinGroupManager
    {
        private readonly IJoinGroupRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public JoinGroupManager(IJoinGroupRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(JoinGroupAddModel model)
        {
            await _repository.AddJoinGroupAsync(JoinGroupFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
