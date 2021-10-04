using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.NextDoorUser;

using UserManagement.Infrastructure.Repositories;

using System.Linq;
using System.Linq.Dynamic.Core;

using Microsoft.EntityFrameworkCore;
using NextDoor.DataLayer;
using NextDoor.Entities;

namespace UserManagement.DataLayer.Repositories
{
    public  class NextDoorUserRepository : INextDoorUserRepository
    {

        private readonly DataContext _dataContext;

        public NextDoorUserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        /*public async Task<NextDoorUserDto> GetByNextDoorUserEmailAsync(string Email)
        {
            return await (from s in _dataContext.NextDoorUser
                          where s.Email == Email
                          select new NextDoorUserDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender  = s.Gender,
                             
                              StreetAdress = s.StreetAdress,
                              ApartmentNo = s.ApartmentNo,
                              Email = s.Email,
                              Lan = s.Lan,
                              Lat = s.Lat
                             
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }*/
        public async Task AddAsync(NextDoorUser entity)
        {
            await _dataContext.NextDoorUser.AddAsync(entity);
        }


       /* public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.NextDoorUser.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.NextDoorUser.Update(data);
        }

        public async Task<List<NextDoorUserDto>> GetAllAsync()
        {
            return await (from s in _dataContext.NextDoorUser

                          select new NextDoorUserDto
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                              Password = s.StreetAdress,
                              StreetAdress = s.StreetAdress,
                              ApartmentNo = s.ApartmentNo,
                              Email = s.Email,
                              Lan = s.Lan,
                              Lat = s.Lat,
                              Status = s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<NextDoorUserDto> GetByUserAsync(string email)
        {
            return await (from s in _dataContext.NextDoorUser
                          where s.Email == email
                          select new NextDoorUserDto
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                              Password = s.Password,
                              StreetAdress = s.StreetAdress,
                              Email = s.Email,
                              ApartmentNo = s.ApartmentNo,
                              Lan = s.Lan,
                              Lat = s.Lat,
                              
                              Status = s.Status,
                              


                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
*/
        
    }
}
