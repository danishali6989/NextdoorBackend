using NextDoor.Dtos.Group;
using NextDoor.Models.Group;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IGroupManager
    {
        Task AddAsync(GroupAddModel model);
        Task EditAsync(GroupEditModel model);
        Task<List<GroupDetailDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
