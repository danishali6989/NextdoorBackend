using NextDoor.Dtos.Neighbourhood;
using NextDoor.Models.Location;
using NextDoor.Models.Neigbourhood;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
   public  interface INeighbourhoodManager
    {
        Task AddAsync(NeighbourhoodAddModel model);
        Task AddLocation(AddLocationModel model);
        Task EditAsync(NeighbourhoodAddModel model);
        Task<NeighbourhoodDetailDto> GetDetailAsync(int id);
        Task<NeighbourhoodDetailDto> GetDetail(int userid);
        Task DeleteAsync(int id);
        Task<List<NeighbourhoodDetailDto>> GetAllAsync();
    }
}
