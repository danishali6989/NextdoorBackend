using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Comment;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Comment;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class CommentManager : ICommentManager
    {
        private readonly ICommentRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public CommentManager(IHttpContextAccessor contextAccessor,
          ICommentRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(CommentAddModel model)
        {
            await _repository.AddCommentAsync(CommentFactory.CreateComment(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task EditAsync(CommentEditModel model)
        {
            var item = await _repository.getCommentdetail(model.Id);
            CommentFactory.EditComment(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<CommentDetailDto>> GetAllCommentByPostIdAsync(int postId)
        {
            return await _repository.GetAllCommentByPostId(postId);

        }
        public async Task<List<CommentDetailDto>> GetAllCommentByIdAsync(int Id)
        {
            return await _repository.GetAllCommentById(Id);

        }


    }
}
