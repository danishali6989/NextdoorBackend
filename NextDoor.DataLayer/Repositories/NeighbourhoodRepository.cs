using NextDoor.Dtos.Neighbourhood;
using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using NextDoor.Utilities;

namespace NextDoor.DataLayer.Repositories
{
    public class NeighbourhoodRepository : INeighbourhoodRepository
    {
        private readonly DataContext _dataContext;

        public NeighbourhoodRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        public async Task AddAsync(Neighbourhood entity)
        {
            await _dataContext.Neighbourhood.AddAsync(entity);
        }
        public async Task AddLocation(Location entity)
        {
            await _dataContext.Location.AddAsync(entity);
        }
        public async Task<Neighbourhood> GetAsync(int id)
        {
            return await _dataContext.Neighbourhood.FindAsync(id);
        }

        public void Edit(Neighbourhood entity)
        {
            _dataContext.Neighbourhood.Update(entity);
        }
        public async Task<NeighbourhoodDetailDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.Neighbourhood
                          where s.Id == id
                          select new NeighbourhoodDetailDto
                          {
                              id = s.Id,
                              userid = s.Userid,
                              Neighbourhood_Name = s.NeighbourhoodName,
                              CreatedOn = s.CreatedOn,
                              
                              Status = s.Status

                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task<NeighbourhoodDetailDto> GetDetail(int userid)
        {
            return await (from s in _dataContext.Neighbourhood
                          where s.Userid == userid
                          select new NeighbourhoodDetailDto
                          {
                              id = s.Id,
                              userid = s.Userid,
                              Neighbourhood_Name = s.NeighbourhoodName,
                              CreatedOn = s.CreatedOn,
                              Status = s.Status
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.Neighbourhood.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Neighbourhood.Update(data);
        }

        public async Task DeleteLocation(int id)
        {
            var data1 = _dataContext.Location.Where(x => x.id == id).FirstOrDefault();

            _dataContext.Location.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }


        public async Task<List<NeighbourhoodDetailDto>> GetAllAsync()
        {
            return await (from s in _dataContext.Neighbourhood
                          
                          select new NeighbourhoodDetailDto
                          {
                              id = s.Id,
                              userid = s.Userid,
                              Neighbourhood_Name = s.NeighbourhoodName,
                              CreatedOn = s.CreatedOn,
                              Status = s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<AddLocation>> getlocationbyuserid(int userid)
        {
            return await (from s in _dataContext.Location
                          where s.UserId == userid

                          select new AddLocation
                          {
                              lat = s.lat,
                              lng = s.lng,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<List<AddLocation>> getlocation(int id)
        {
            return await (from s in _dataContext.Location
                          where s.NeighbourhoodId == id

                          select new AddLocation
                          {
                              lat = s.lat,
                              lng = s.lng,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

    }
}
