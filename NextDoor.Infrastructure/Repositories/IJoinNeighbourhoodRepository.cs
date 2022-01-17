using NextDoor.Dtos.JoinNeighbourhood;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IJoinNeighbourhoodRepository
    {
        Task AddAsync(JoinNeighbourhood entity);
        Task<JoinNeighbourhoodDto> checkuserjoin(int userid);
    }
}
