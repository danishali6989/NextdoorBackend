using NextDoor.Dtos.Like;
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
    public class LikeRepository : ILikeRepository
    {
        private readonly DataContext _dataContext;

        public LikeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddLikeAsync(Likes entity)
        {
            await _dataContext.Likes.AddAsync(entity);
        }

        public async Task<List<LikeDetailDto>> GetAllByUserId(int userId)
        {
            return await (from s in _dataContext.Likes
                          where s.User_id == userId

                          select new LikeDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              CommentId = s.Comment_id,
                              Reaction_Id  = s.Reaction_Id,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<LikeDetailDto>> GetAllLikesByCommentId(int CommentId)
        {
            return await (from s in _dataContext.Likes
                          where  s.Comment_id == CommentId

                          select new LikeDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              CommentId = s.Comment_id,
                              Reaction_Id = s.Reaction_Id,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        /*public Constants.ReactionStatus getreactionId(int CommentId)
        {
            return (from s in _dataContext.Likes
                    where s.Comment_id == CommentId

                    select new LikeDetailDto
                    {

                        Reaction_Id = s.Reaction_Id,
                    })
                          .AsNoTracking()
                          .ToListAsync();
            var cmntid = _dataContext.Likes.Where(x=> x.Comment_id == CommentId).FirstOrDefault();
            if(cmntid == null)
            {
                cmntid.Reaction_Id = 0;
                return cmntid.Reaction_Id;
            }
            else
            {

            return cmntid.Reaction_Id;
            }
        }*/
        public async Task<LikeDetailDto> GetLikeByUserAsync(int userId, int postId)
        {
            return await (from s in _dataContext.Likes
                          where s.User_id == userId && s.Post_id == postId 
                          select new LikeDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              Reaction_Id = s.Reaction_Id,
                              CommentId = s.Comment_id,
                              


                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
        public async Task<LikeDetailDto> CheckPostCommentLike(int userId, int postId,int commentid)
        {
            return await (from s in _dataContext.Likes
                          where s.User_id == userId && s.Post_id == postId && s.Comment_id == commentid
                          select new LikeDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              Reaction_Id = s.Reaction_Id,
                              CommentId = s.Comment_id,



                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
        public async Task<LikeDetailDto> CheckEventCommentLike(int userId, int eventid, int commentid)
        {
            return await (from s in _dataContext.Likes
                          where s.User_id == userId && s.Event_id == eventid && s.Comment_id == commentid
                          select new LikeDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              Reaction_Id = s.Reaction_Id,
                              CommentId = s.Comment_id,



                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task<LikeDetailDto> CheckPollCommentLike(int userId, int pollid, int commentid)
        {
            return await (from s in _dataContext.Likes
                          where s.User_id == userId && s.Poll_id == pollid && s.Comment_id == commentid
                          select new LikeDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              Reaction_Id = s.Reaction_Id,
                              CommentId = s.Comment_id,
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task<LikeDetailDto> GetEventLikeByUserAsync(int userId, int eventid)
        {
            return await (from s in _dataContext.Likes
                          where s.User_id == userId && s.Event_id == eventid
                          select new LikeDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              Reaction_Id = s.Reaction_Id,
                              CommentId = s.Comment_id,



                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
        public async Task<LikeDetailDto> GetPollLikeByUserAsync(int userId, int pollid)
        {
            return await (from s in _dataContext.Likes
                          where s.User_id == userId && s.Poll_id == pollid
                          select new LikeDetailDto
                          {
                              Id = s.Id,
                              User_Id = s.User_id,
                              PostId = s.Post_id,
                              EventId = s.Event_id,
                              Reaction_Id = s.Reaction_Id,
                              CommentId = s.Comment_id,



                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task EditReaction(int userid,int postid, Constants.ReactionStatus reactionid)
        {
            var data =  _dataContext.Likes.Where(x => x.User_id == userid && x.Post_id == postid).FirstOrDefault();
            data.Reaction_Id = reactionid;
            _dataContext.Likes.Update(data);
            await _dataContext.SaveChangesAsync();
        }
        public async Task EditCommentReaction(int userid, int postid,int commentid, Constants.ReactionStatus reactionid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Post_id == postid && x.Comment_id == commentid).FirstOrDefault();
            data.Reaction_Id = reactionid;
            _dataContext.Likes.Update(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task EditEventCommentReaction(int userid, int eventid, int commentid, Constants.ReactionStatus reactionid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Event_id == eventid && x.Comment_id == commentid).FirstOrDefault();
            data.Reaction_Id = reactionid;
            _dataContext.Likes.Update(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task EditPollCommentReaction(int userid, int pollid, int commentid, Constants.ReactionStatus reactionid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Poll_id == pollid && x.Comment_id == commentid).FirstOrDefault();
            data.Reaction_Id = reactionid;
            _dataContext.Likes.Update(data);
            await _dataContext.SaveChangesAsync();
        }
        public async Task EditEventReaction(int userid, int eventid, Constants.ReactionStatus reactionid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Event_id == eventid).FirstOrDefault();
            data.Reaction_Id = reactionid;
            _dataContext.Likes.Update(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task EditPollReaction(int userid, int pollid, Constants.ReactionStatus reactionid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Poll_id == pollid).FirstOrDefault();
            data.Reaction_Id = reactionid;
            _dataContext.Likes.Update(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteLike(int userid,int postid)
        {
            var data = _dataContext.Likes.Where(x=> x.User_id == userid && x.Post_id == postid).FirstOrDefault();
            _dataContext.Likes.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteCommentLike(int userid, int postid,int commentid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Post_id == postid && x.Comment_id == commentid).FirstOrDefault();
            _dataContext.Likes.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteEventCommentLike(int userid, int eventid, int commentid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Event_id == eventid && x.Comment_id == commentid).FirstOrDefault();
            _dataContext.Likes.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeletePollCommentLike(int userid, int pollid, int commentid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Poll_id == pollid && x.Comment_id == commentid).FirstOrDefault();
            _dataContext.Likes.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteEventLike(int userid, int eventid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Event_id == eventid).FirstOrDefault();
            _dataContext.Likes.Remove(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeletePollLike(int userid, int pollid)
        {
            var data = _dataContext.Likes.Where(x => x.User_id == userid && x.Poll_id == pollid).FirstOrDefault();
            _dataContext.Likes.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
    }
}
