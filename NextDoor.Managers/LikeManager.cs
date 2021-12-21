using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Like;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Likes;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class LikeManager : ILikeManager
    {
        private readonly ILikeRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public LikeManager(IHttpContextAccessor contextAccessor,
          ILikeRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(LikesAddModel model)
        {
            await _repository.AddLikeAsync(LikeFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<LikeDetailDto>> GetAllByUserIdAsync(int userId)
        {
            return await _repository.GetAllByUserId(userId);

        }

        public async Task<List<LikeDetailDto>> GetAllLikesByCommentIdAsync(int CommentId)
        {
            return await _repository.GetAllLikesByCommentId(CommentId);

        }

        public async Task<LikeDetailDto> CheckUserLike(int userId, int postId )
        {
            return await _repository.GetLikeByUserAsync( userId, postId);
        }
        public async Task<LikeDetailDto> CheckPostCommentLike(int userId, int postId,int commentid)
        {
            return await _repository.CheckPostCommentLike(userId, postId,commentid);
        }
        public async Task<LikeDetailDto> CheckEventUserLike(int userId, int eventid)
        {
            return await _repository.GetEventLikeByUserAsync(userId, eventid);
        }
        public async Task<LikeDetailDto> CheckPollUserLike(int userId, int pollid)
        {
            return await _repository.GetPollLikeByUserAsync(userId, pollid);
        }
        public async Task<LikeDetailDto> CheckEventCommentLike(int userId, int eventid,int commentid)
        {
            return await _repository.CheckEventCommentLike(userId, eventid,commentid);
        }

        public async Task<LikeDetailDto> CheckPollCommentLike(int userId, int pollid, int commentid)
        {
            return await _repository.CheckPollCommentLike(userId, pollid, commentid);
        }

        public async Task EditLikeReaction(int userid, int postId, Constants.ReactionStatus reactionid)
        {
            
            await _repository.EditReaction(userid,postId,reactionid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditCommentLikeReaction(int userid, int postId,int commentid, Constants.ReactionStatus reactionid)
        {

            await _repository.EditCommentReaction(userid, postId,commentid, reactionid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditEventCommentLikeReaction(int userid, int eventid, int commentid, Constants.ReactionStatus reactionid)
        {

            await _repository.EditEventCommentReaction(userid, eventid, commentid, reactionid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditPollCommentLikeReaction(int userid, int pollid, int commentid, Constants.ReactionStatus reactionid)
        {

            await _repository.EditPollCommentReaction(userid, pollid, commentid, reactionid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditEventLikeReaction(int userid, int eventid, Constants.ReactionStatus reactionid)
        {

            await _repository.EditEventReaction(userid, eventid, reactionid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditPollLikeReaction(int userid, int pollid, Constants.ReactionStatus reactionid)
        {

            await _repository.EditPollReaction(userid, pollid, reactionid);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteLike(int userid,int postid)
        {
            await _repository.DeleteLike(userid,postid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteCommentLike(int userid, int postid,int commentid)
        {
            await _repository.DeleteCommentLike(userid, postid,commentid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteEventCommentLike(int userid, int eventid, int commentid)
        {
            await _repository.DeleteEventCommentLike(userid, eventid, commentid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeletePollCommentLike(int userid, int pollid, int commentid)
        {
            await _repository.DeletePollCommentLike(userid, pollid, commentid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteEventLike(int userid, int eventid)
        {
            await _repository.DeleteEventLike(userid, eventid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeletePollLike(int userid, int pollid)
        {
            await _repository.DeletePollLike(userid, pollid);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
