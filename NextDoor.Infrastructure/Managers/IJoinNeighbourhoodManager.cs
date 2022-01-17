using NextDoor.Dtos.JoinNeighbourhood;
using NextDoor.Models.JoinNeighbourhood;
using NextDoor.Models.Neigbourhood;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IJoinNeighbourhoodManager
    {
        Task AddAsync(JoinNeighbourhoodAddModel model);
        Task JoinAsync(NeighbourhoodAddModel model);
        Task<JoinNeighbourhoodDto> checkjoin(int userid);
    }
}
