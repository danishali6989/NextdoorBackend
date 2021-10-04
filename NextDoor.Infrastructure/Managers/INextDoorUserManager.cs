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
        /*Task<NextDoorUserDto> CheckNextDoorUserEmail(string Email);

        Task DeleteAsync(int id);
        Task<List<NextDoorUserDto>> GetAllAsync();

        Task<NextDoorUserDto> CheckUser(string email);*/
        
    }
}
