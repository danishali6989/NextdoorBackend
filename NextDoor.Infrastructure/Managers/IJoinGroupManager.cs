using NextDoor.Models.Group;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IJoinGroupManager
    {
        Task AddAsync(JoinGroupAddModel model);
    }
}
