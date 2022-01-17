using NextDoor.Dtos.JoinNeighbourhood;
using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace NextDoor.DataLayer.Repositories
{
    public  class JoinNeighbourhoodRepository : IJoinNeighbourhoodRepository
    {
        public readonly DataContext _dataContext;

        public JoinNeighbourhoodRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(JoinNeighbourhood entity)
        {
            await _dataContext.JoinNeighbourhood.AddAsync(entity);
        }


        public async Task<JoinNeighbourhoodDto> checkuserjoin(int userid)
        {
            return await (from s in _dataContext.JoinNeighbourhood
                          where s.UserId == userid
                          select new JoinNeighbourhoodDto
                          {
                              id = s.Id,
                              NeighbourhoodId = s.NeighbourhoodId,
                              userid = s.UserId,
                              CreatedOn = s.CreatedOn,
                              Status = s.Status,
                              
                          })
                           .AsNoTracking()
                           .SingleOrDefaultAsync();
        }
    }
}
