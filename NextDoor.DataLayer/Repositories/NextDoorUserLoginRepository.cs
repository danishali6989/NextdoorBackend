using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Dtos.NextDoorUser;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NextDoor.DataLayer.Repositories
{
    public class NextDoorUserLoginRepository : INextDoorUserLoginReository
    {
        private readonly DataContext _dataContext;

        public NextDoorUserLoginRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<NextDoorUserDto> isExist(int userid)
        {
            return await (from s in _dataContext.NextDoorUser
                          where s.UserId == userid
                          select new NextDoorUserDto
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                              StreetAdress = s.StreetAdress,
                              ApartmentNo = s.ApartmentNo,
                              Email = s.Email,
                              Lan = s.Lan,
                              Lat = s.Lat,
                            

                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
    }
}
