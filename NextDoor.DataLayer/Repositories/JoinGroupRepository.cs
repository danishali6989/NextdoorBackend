using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.DataLayer.Repositories
{
    public class JoinGroupRepository: IJoinGroupRepository
    {
        private readonly DataContext _dataContext;
        public JoinGroupRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task AddJoinGroupAsync(JoinGroup entity)
        {
            await _dataContext.JoinGroup.AddAsync(entity);
        }
    }
}
