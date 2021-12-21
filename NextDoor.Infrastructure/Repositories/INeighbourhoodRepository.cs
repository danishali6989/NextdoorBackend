using NextDoor.Dtos.Neighbourhood;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface INeighbourhoodRepository
    {

        Task AddAsync(Neighbourhood entity);
        Task AddLocation(Location entity);
        Task<Neighbourhood> GetAsync(int id);
        void Edit(Neighbourhood entity);
        Task<NeighbourhoodDetailDto> GetDetailAsync(int id);
        Task<NeighbourhoodDetailDto> GetDetail(int userid);
        Task DeleteAsync(int id);
        Task<List<NeighbourhoodDetailDto>> GetAllAsync();
        Task<List<AddLocation>> getlocationbyuserid(int userid);
        Task<List<AddLocation>> getlocation(int id);
        Task DeleteLocation(int id);
    }
}
