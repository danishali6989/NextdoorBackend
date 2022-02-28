using NextDoor.Dtos.HelpMap;
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
    public class HelpMapRepository:IHelpMapRepository
    {
        private readonly DataContext _dataContext;
        public HelpMapRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task AddMessage(HelpMap entity)
        {
             _dataContext.HelpMap.Add(entity);
        }
        public async Task<HelpMap> GetAsync(int id)
        {
            return await _dataContext.HelpMap.FindAsync(id);
        }
        public void Edit(HelpMap entity)
        {
            _dataContext.HelpMap.Update(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var obj = _dataContext.HelpMap.Where(x => x.Id == id).FirstOrDefault();
            _dataContext.HelpMap.Remove(obj);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<List<HelpMapDto>> GetAllAsync()
        {
            return await (from s in _dataContext.HelpMap
                          select new HelpMapDto
                          {
                              id = s.Id,
                              Message = s.Message,
                              ParentMessageId = s.ParentMessageId,
                              FirstName = s.NextDoorUser.FirstName,
                              LastName = s.NextDoorUser.LastName,
                              lat = s.lat,
                              lng = s.lng,
                              UserId = s.UserId,
                              CreatedOn = s.CreatedOn,
                             CreatedBy = s.CreatedBy,
                             UpdatedOn = s.UpdatedOn,
                             UpdatedBy = s.UpdatedBy
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

    }
}
