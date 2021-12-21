using NextDoor.Dtos.Like;
using NextDoor.Entities;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface ILikeRepository
    {
        Task AddLikeAsync(Likes entity);
        Task<List<LikeDetailDto>> GetAllByUserId(int useId);
        Task<List<LikeDetailDto>> GetAllLikesByCommentId(int CommentId);
       // Constants.ReactionStatus getreactionId(int Commentid);
        //  Task<LikeDetailDto> GetByUserAsync(Likes entity);
        Task<LikeDetailDto> GetLikeByUserAsync(int userId, int postId);
        Task<LikeDetailDto> CheckPostCommentLike(int userId, int postId,int commentid);
        Task<LikeDetailDto> CheckEventCommentLike(int userId, int eventid, int commentid);
        Task<LikeDetailDto> CheckPollCommentLike(int userId, int pollid, int commentid);
        Task<LikeDetailDto> GetEventLikeByUserAsync(int userId, int eventid);
        Task<LikeDetailDto> GetPollLikeByUserAsync(int userId, int pollid);
        Task EditReaction(int userid,int postid, Constants.ReactionStatus reactionid);
        Task EditCommentReaction(int userid, int postid,int commentid,Constants.ReactionStatus reactionid);
        Task EditEventCommentReaction(int userid, int eventid, int commentid, Constants.ReactionStatus reactionid);
        Task EditPollCommentReaction(int userid, int pollid, int commentid, Constants.ReactionStatus reactionid);
        Task EditEventReaction(int userid, int eventid, Constants.ReactionStatus reactionid);
        Task EditPollReaction(int userid, int pollid, Constants.ReactionStatus reactionid);
        Task DeleteLike(int userid,int postid);
        Task DeleteCommentLike(int userid, int postid,int commentid);
        Task DeleteEventCommentLike(int userid, int eventid, int commentid);
        Task DeletePollCommentLike(int userid, int pollid, int commentid);
        Task DeleteEventLike(int userid, int eventid);
        Task DeletePollLike(int userid, int pollid);
    }
}
