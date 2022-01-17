using NextDoor.Dtos.Group;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IGroupRepository
    {
        Task AddGroupAsync(Group entity );
        Task<List<GroupDetailDto>> getallgroup();
        Task<Group> GetAsync(int id);
        Task deletegroup(int id);
        void Edit(Group entity);
    }
}
