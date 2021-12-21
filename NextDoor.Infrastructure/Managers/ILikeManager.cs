using NextDoor.Dtos.Like;
using NextDoor.Models.Likes;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface ILikeManager
    {
        Task AddAsync(LikesAddModel model);
        Task<List<LikeDetailDto>> GetAllByUserIdAsync(int userId);
        Task<LikeDetailDto> CheckUserLike(int userId,int postId);
        Task<LikeDetailDto> CheckPostCommentLike(int userId, int postId,int commentid);
        Task<LikeDetailDto> CheckEventUserLike(int userId, int eventid);
        Task<LikeDetailDto> CheckPollUserLike(int userId, int pollid);
        Task<LikeDetailDto> CheckEventCommentLike(int userId, int eventid,int commentid);
        Task<LikeDetailDto> CheckPollCommentLike(int userId, int pollid, int commentid);
        Task EditLikeReaction(int userid,int postid, Constants.ReactionStatus reactionid);
        Task EditCommentLikeReaction(int userid, int postid,int commentid, Constants.ReactionStatus reactionid);
        Task EditEventCommentLikeReaction(int userid, int eventid, int commentid, Constants.ReactionStatus reactionid);
        Task EditPollCommentLikeReaction(int userid, int pollid, int commentid, Constants.ReactionStatus reactionid);
        Task EditEventLikeReaction(int userid, int eventid, Constants.ReactionStatus reactionid);
        Task EditPollLikeReaction(int userid, int pollid, Constants.ReactionStatus reactionid);
        Task<List<LikeDetailDto>> GetAllLikesByCommentIdAsync(int postId);
        Task DeleteLike(int userid, int postid);
        Task DeleteCommentLike(int userid, int postid,int commentid);
        Task DeleteEventCommentLike(int userid, int eventid, int commentid);
        Task DeletePollCommentLike(int userid, int pollid, int commentid);
        Task DeleteEventLike(int userid, int eventid);
        Task DeletePollLike(int userid, int pollid);

    }
}
