using NextDoor.Dtos.BusinessType;
using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using NextDoor.Utilities;

namespace NextDoor.DataLayer.Repositories
{
    public  class BusinessTypeRepository: IBusinessTypeRepository
    {
        public readonly DataContext _datacontext;
        public BusinessTypeRepository(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public async Task AddAsync(BusinessType entity)
        {
            await _datacontext.BusinessType.AddAsync(entity);
            await _datacontext.SaveChangesAsync();
        }
        public async Task<BusinessType> GetRecord(int id)
        {
            return await _datacontext.BusinessType.FindAsync(id);
        }
        public void  Edit(BusinessType entity)
        {
            _datacontext.BusinessType.Update(entity);
            _datacontext.SaveChanges();
        }

        public async Task<BusinessTypeDetailDto> GetDetail(int id)
        {
            return await (from s in _datacontext.BusinessType
                          where s.Id == id
                          select new BusinessTypeDetailDto 
                          {
                             Id = s.Id,
                             BusinessName = s.BusinessName,
                             UserId= s.UserId,
                             CreatedOn = s.CreatedOn,
                             CreatedBy = s.CreatedBy,
                             UpdatedOn = s.UpdatedOn,
                             UpdatedBy = s.UpdatedBy
                          }).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<BusinessTypeDetailDto>> GetAllAsync()
        {
            return await (from s in _datacontext.BusinessType
                          where s.Status != Constants.RecordStatus.Deleted
                          select new BusinessTypeDetailDto 
                          {
                              Id = s.Id,
                              BusinessName = s.BusinessName,
                              UserId =s.UserId,
                              Status = s.Status,
                              CreatedOn = s.CreatedOn,
                              CreatedBy = s.CreatedBy,
                              UpdatedOn = s.UpdatedOn,
                              UpdatedBy = s.UpdatedBy
                          }).AsNoTracking().ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _datacontext.BusinessType.FindAsync(id);
            item.Status = Constants.RecordStatus.Deleted;
            _datacontext.BusinessType.Update(item);
        }
    }
}
