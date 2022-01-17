using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.NextDoorUser;


namespace UserManagement.Infrastructure.Repositories
{
    public interface INextDoorUserRepository
    {
        Task AddAsync(NextDoorUser entity);
        Task<NextDoorUserDto> GetByUserEmailAsync(string email);
        Task<NextDoorUserDto> GetByUseridAsync(int userid);
        Task<NextDoorUserDto> getuserdetail(string username);
        Task<NextDoorUser> GetAsync(int userid);
        void Edit(NextDoorUser entity);
        

        Task<List<NextDoorUserDto>> GetUserList(string PostalCode);

       /* Task DeleteAsync(int id);
        Task<NextDoorUserDto> GetByUserAsync(string email);
*/
    }
}
