using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.NextDoorUser;

namespace NextDoor.Infrastructure.Repositories
{
    public interface INextDoorUserLoginReository
    {
        Task<NextDoorUserDto> isExist(int userid);
    }
}
