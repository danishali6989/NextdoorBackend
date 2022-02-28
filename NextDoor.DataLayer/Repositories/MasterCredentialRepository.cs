using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.DataLayer.Repositories
{
    public class MasterCredentialRepository : IMasterCredentialRepository
    {
        private readonly DataContext _dataContext;
        public MasterCredentialRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        public async Task AddAsync(MasterCredential entity)
        {
            await _dataContext.MasterCredential.AddAsync(entity);
        }

    }
}
