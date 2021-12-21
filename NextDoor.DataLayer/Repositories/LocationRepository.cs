using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.DataLayer.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _dataContext;

        public LocationRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
        }
        public async Task AddAsync(Location entity)
        {
            await _dataContext.Location.AddAsync(entity);
        }
    }
}
