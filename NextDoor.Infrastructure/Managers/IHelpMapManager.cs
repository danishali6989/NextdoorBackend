using NextDoor.Dtos.HelpMap;
using NextDoor.Models.HelpMap;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IHelpMapManager
    {
        Task AddMessage(AddHelpMapModel model);
        Task EditAsync(EditHelpMapModel model);
        Task<List<HelpMapDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
