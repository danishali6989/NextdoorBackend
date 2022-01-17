using NextDoor.Dtos.Comment;
using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using NextDoor.Dtos.Like;
using NextDoor.Utilities;

namespace NextDoor.DataLayer.Repositories
{
    public  class CommentRepository : ICommentRepository
    {
        private readonly DataContext _dataContext;

        public CommentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddCommentAsync(Comment entity)
        {
            await _dataContext.Comment.AddAsync(entity);
        }
        public async Task Edit(Comment entity)
        {
             _dataContext.Comment.Update(entity);
        }
        public async Task<Comment> getCommentdetail(int id)
        {
            return await _dataContext.Comment.FindAsync(id);
        }
        public async Task<List<CommentDetailDto>> GetAllCommentByPostId(int postId)
        {
            return await (from s in _dataContext.Comment
                         
                          where s.Post_id == postId && s.CommentParent_Id==0

                          select new CommentDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              FirstName = s.NextDoorUser.FirstName,
                              LastName = s.NextDoorUser.LastName,
                              PostId = s.Post_id,
                              Comment_Parent_Id = s.CommentParent_Id,
                              CommentText = s.CommentText,
                              Attachment1 = s.Attachment1,
                              Attachment2 = s.Attachment2,
                              Attachment3 = s.Attachment3,
                              AttachmentType1 = s.AttachmentType1,
                              AttachmentType2 = s.AttachmentType2,
                              AttachmentType3 = s.AttachmentType3,
                            //  TimeStamp = s.TimeStamp,
                              Lan = s.lng,
                              Lat = s.lat,
                              Status = s.Status,
                             
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<CommentDetailDto>> GetAllCommentById(int Id)
        {
            return await (from s in _dataContext.Comment
                          where s.CommentParent_Id == Id

                          select new CommentDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              FirstName = s.NextDoorUser.FirstName,
                              LastName = s.NextDoorUser.LastName,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              Comment_Parent_Id = s.CommentParent_Id,
                              CommentText = s.CommentText,
                              Attachment1 = s.Attachment1,
                              Attachment2 = s.Attachment2,
                              Attachment3 = s.Attachment3,
                            //  TimeStamp = s.TimeStamp,
                              AttachmentType1 = s.AttachmentType1,
                              AttachmentType2 = s.AttachmentType2,
                              AttachmentType3 = s.AttachmentType3,
                              Lan = s.lng,
                              Lat = s.lat,
                              Status = s.Status,


                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task DeleteAsync(int commentid)
        {
            var data = await _dataContext.Comment.FindAsync(commentid);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Comment.Update(data);
        }
    }
}
