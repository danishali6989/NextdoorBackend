using NextDoor.Dtos.BusinessType;
using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IBusinessTypeRepository
    {
        Task AddAsync(BusinessType entity);
        Task<BusinessType> GetRecord(int id);
        void Edit(BusinessType entity);
        Task<BusinessTypeDetailDto> GetDetail(int id);
        Task<List<BusinessTypeDetailDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
