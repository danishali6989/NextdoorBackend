using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.BusinessType;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.BusinessType;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class BusinessTypeManager : IBusinessTypeManager
    {
        public readonly IBusinessTypeRepository _repository;
        private readonly string _userId;
        private readonly IUnitOfWork _unitOfWork;
        public BusinessTypeManager(IHttpContextAccessor contextAccessor,IBusinessTypeRepository repository
            ,IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddBusinessTypeModel model)
        {
            await _repository.AddAsync(BusinessTypeFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(AddBusinessTypeModel model)
        {
            var item = await _repository.GetRecord(model.Id);
            BusinessTypeFactory.Create(item,model,_userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<BusinessTypeDetailDto> GetDetail(int id)
        {
            return await _repository.GetDetail(id);
        }

        public async Task<List<BusinessTypeDetailDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
