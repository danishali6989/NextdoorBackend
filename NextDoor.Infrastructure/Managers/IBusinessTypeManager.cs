using NextDoor.Dtos.BusinessType;
using NextDoor.Models.BusinessType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IBusinessTypeManager
    {
        Task AddAsync(AddBusinessTypeModel model);
        Task EditAsync(AddBusinessTypeModel model);
        Task<BusinessTypeDetailDto> GetDetail(int id);
        Task<List<BusinessTypeDetailDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
