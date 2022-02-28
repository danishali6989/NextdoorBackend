using NextDoor.Dtos.HelpMap;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IHelpMapRepository
    {
        Task AddMessage(HelpMap entity);
        Task<HelpMap> GetAsync(int id);
        void Edit(HelpMap entity);
        Task<List<HelpMapDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
