using NextDoor.Dtos.Group;
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
    public class GroupRepository: IGroupRepository
    {
      
        public readonly DataContext _dataContext;

        public GroupRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddGroupAsync(Group entity)
        {
            await _dataContext.Group.AddAsync(entity);
        }

        public async Task deletegroup(int id)
        {
            var data = await _dataContext.Group.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Group.Update(data);
        }

        public async Task<List<GroupDetailDto>> getallgroup()
        {
            return await (from s in _dataContext.Group

                          select new GroupDetailDto
                          {
                              Id = s.Id,
                              UserID = s.UserID,
                              GroupName = s.GroupName,
                            //  TimeStamp = s.GroupTimeStamp
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _dataContext.Group.FindAsync(id);
        }

        public void Edit(Group entity)
        {
            _dataContext.Group.Update(entity);
        }

    }
}
