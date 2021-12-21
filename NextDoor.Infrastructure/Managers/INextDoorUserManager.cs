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
        //  Task<NextDoorUserDto> CheckNextDoorUser(string U_Fname);
        Task EditAsync(EditNextDoorUser model);
        Task<NextDoorUserDto> CheckNextDoorUserEmail(string Email);

        /*Task DeleteAsync(int id);
        Task<List<NextDoorUserDto>> GetAllAsync();*/


    }
}
