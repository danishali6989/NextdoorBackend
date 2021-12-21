using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.NextDoorUser;

namespace NextDoor.Infrastructure.Managers
{
    public interface INextDoorUserLoginManager
    {
        Task<NextDoorUserDto> isExist(int userid);
    }
}
