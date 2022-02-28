using NextDoor.Models.NextDoorUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.NextDoorUser;


namespace UserManagement.Infrastructure.Managers
{
   public interface INextDoorUserManager
    {
        Task AddAsync(AddNextDoorUserModel model,string header);
        Task EditAsync(EditNextDoorUser model);
        Task<NextDoorUserDto> CheckNextDoorUserEmail(string Email);
        Task<NextDoorUserDto> getuser(string username);
        Task<NextDoorUserDto> CheckNextDoorUser(int userid);
        Task<List<NextDoorUserDto>> GetUserList(string PostalCode);
    }
}
