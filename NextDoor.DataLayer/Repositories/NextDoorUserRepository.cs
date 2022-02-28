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

        public async Task<NextDoorUserDto> GetByUserEmailAsync(string Email)
        {
            return await (from s in _dataContext.NextDoorUser
                          where s.Email == Email
                          select new NextDoorUserDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                              StreetAdress = s.StreetAdress,
                              ApartmentNo = s.ApartmentNo,
                              Email = s.Email,
                              Lan = s.Lan,
                              Lat = s.Lat
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task<NextDoorUserDto> GetByUseridAsync(int userid)
        {
            return await (from s in _dataContext.NextDoorUser
                          where s.UserId == userid
                          select new NextDoorUserDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                              PostalCode = s.Postalcode,
                              StreetAdress = s.StreetAdress,
                              ApartmentNo = s.ApartmentNo,
                              Email = s.Email,
                              Lan = s.Lan,
                              Lat = s.Lat

                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
        public async Task<NextDoorUserDto> getuserdetail(string username)
        {
            return await (from s in _dataContext.NextDoorUser
                          where s.Email == username
                          select new NextDoorUserDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                              StreetAdress = s.StreetAdress,
                              PostalCode = s.Postalcode,
                              ApartmentNo = s.ApartmentNo,
                              Email = s.Email,
                              Lan = s.Lan,
                              Lat = s.Lat
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
        public async Task AddAsync(NextDoorUser entity)
        {
            await _dataContext.NextDoorUser.AddAsync(entity);
        }

        public async Task<NextDoorUser> GetAsync(int userid)
        {
            var data1 = _dataContext.NextDoorUser.Where(x => x.UserId == userid).FirstOrDefault();
            return data1;
        }
        public void Edit(NextDoorUser entity)
        {
            _dataContext.NextDoorUser.Update(entity);
        }
      
        public async Task<List<NextDoorUserDto>> GetUserList(string PostalCode)
        {
            return await (from s in _dataContext.NextDoorUser
                          where s.Postalcode == PostalCode
                          select new NextDoorUserDto
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                              City = s.City,
                              State = s.State,
                              FAPronounce = s.FAPreference,
                              PostalCode = s.Postalcode,
                              StreetAdress = s.StreetAdress,
                              ApartmentNo = s.ApartmentNo,
                              Email = s.Email,
                              Lan = s.Lan,
                              Lat = s.Lat,
                              Status = s.Status,
                          })
                          .OrderBy(x=> x.FirstName)
                          .AsNoTracking()
                          .ToListAsync();
        }

      
    }
}
