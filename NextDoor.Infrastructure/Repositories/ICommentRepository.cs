using NextDoor.Dtos.Comment;
using NextDoor.Entities;
using NextDoor.Models.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment model);
        Task Edit(Comment entity);
        Task DeleteAsync(int commentid);
        Task<Comment> getCommentdetail(int id);
        Task<List<CommentDetailDto>> GetAllCommentByPostId(int postId);
        Task<List<CommentDetailDto>> GetAllCommentById(int Id);
    }
}
