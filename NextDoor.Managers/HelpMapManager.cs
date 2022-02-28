using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.HelpMap;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.HelpMap;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class HelpMapManager : IHelpMapManager
    {
        private readonly IHelpMapRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public HelpMapManager(IHttpContextAccessor contextAccessor,IUnitOfWork unitOfWork,IHelpMapRepository repository)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task AddMessage(AddHelpMapModel model)
        {
            try
            {
            await _repository.AddMessage(HelpMapFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task EditAsync(EditHelpMapModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            HelpMapFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<HelpMapDto>> GetAllAsync()
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
