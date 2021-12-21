using NextDoor.Dtos.Comment;
using NextDoor.Models.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface ICommentManager
    {
        Task AddAsync(CommentAddModel model);
        Task EditAsync(CommentEditModel model);
        Task DeleteAsync(int id);
        Task<List<CommentDetailDto>> GetAllCommentByPostIdAsync(int postId);
        Task<List<CommentDetailDto>> GetAllCommentByIdAsync(int Id);
    }
}
