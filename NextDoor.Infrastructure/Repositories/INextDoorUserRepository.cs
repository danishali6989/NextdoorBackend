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
        Task<NextDoorUser> GetAsync(int userid);
        void Edit(NextDoorUser entity);
        /*;


        Task DeleteAsync(int id);
        Task<List<NextDoorUserDto>> GetAllAsync();
        Task<NextDoorUserDto> GetByUserAsync(string email);*/

    }
}
