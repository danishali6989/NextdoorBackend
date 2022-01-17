using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Poll;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Poll;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class PollManager : IPollManager
    {
        private readonly IPollRepository _repository;
        private readonly ICommentRepository _Commentrepository;
        private readonly ILikeRepository _likerepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public PollManager(IHttpContextAccessor contextAccessor,ICommentRepository commentRepository,
          IPollRepository repository, ILikeRepository likeRepository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
            _Commentrepository = commentRepository;
            _likerepository = likeRepository;
        }

        public PollManager()
        {
        }

        public async Task AddPollAsync(PollAddModel model)
        {
            await _repository.AddPollAsync(PollFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        //Add vote
        public async Task AddVoteAsync(VoteAddModel model)
        {
            //add vote count
            var item = await _repository.GetAsync(model.ResponseId);
            PollFactory.CreateCount(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
            await _repository.AddPollUserVoteAsync(PollFactory.CreateUserVote(model, _userId));
            await _unitOfWork.SaveChangesAsync();


        }
        public async Task<PollDetailDto> PollDetail(int user_id)
        {
            return await _repository.PollDetail(user_id);
        }

        public async Task AddPollMultimediaAsync(PollAddModel model)
        {
            await _repository.AddPollMultimediaAsync(PollFactory.CreateMultimedia(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddOptionDetailAsync(AddPollOptionModel model)
        {
            await _repository.AddOptionDetailAsync(PollFactory.CreateResponse(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<PollOptionDetailDto>> GetAllOptionAsync(int pollid)
        {
            return await _repository.GetAllOption(pollid);
        }

        public async Task<List<PollDetailDto>> PollGetAllAsync(int userid)
        {
            var data= await _repository.GetAllPoll();
            foreach(var item in data)
            {
                item.multimedia =await _repository.getPollMultimediByPoll(item.Poll_Id);
                item.MultimediaCount = item.multimedia.Count;
                item.options = await _repository.getPollOptionByPoll(item.Poll_Id);
                item.pollcomment = await _repository.getPollCommentByid(item.Poll_Id);
                item.PollCommentCount = item.pollcomment.Count;
                item.polllike = await _repository.getPolllikesById(item.Poll_Id);
                item.UserReaction_id = _repository.getPollLikesReactionByUserId(userid, item.Poll_Id);

                foreach (var r in item.pollcomment)
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.likes = likes.Count;
                    // r.Reaction_Id =  _likerepository.getreactionId(r.id);
                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            //item1.likes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.Commentlikes = Commentlikes.Count;
                        }
                    }

                }
            }
            return data;
        }


        public async Task<List<PollDetailDto>> PollGetAllBookmarkAsync(int userid)
        {
            var data = await _repository.GetAllPollBookmark(userid);
            foreach (var item in data)
            {
                item.multimedia = await _repository.getPollMultimediByPoll(item.Poll_Id);
                item.options = await _repository.getPollOptionByPoll(item.Poll_Id);
                item.pollcomment = await _repository.getPollCommentByid(item.Poll_Id);
                item.polllike = await _repository.getPolllikesById(item.Poll_Id);
                item.UserReaction_id = _repository.getPollLikesReactionByUserId(userid, item.Poll_Id);

                foreach (var r in item.pollcomment)
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.likes = likes.Count;
                    // r.Reaction_Id =  _likerepository.getreactionId(r.id);
                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            //item1.likes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.Commentlikes = Commentlikes.Count;
                        }
                    }

                }
            }
            return data;
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeletePoll(id);
            await _unitOfWork.SaveChangesAsync();
            var data = await _repository.GetPollDetail(id);
            foreach (var item in data)
            {
                item.multimedia = await _repository.getPollMultimediByPoll(item.Poll_Id);
                foreach (var s in item.multimedia)
                {
                    await _repository.deletemultimedia(s.pollid);
                }
                item.options = await _repository.getPollOptionByPoll(item.Poll_Id);
                foreach (var f in item.options)
                {
                    await _repository.deleteOption(f.pollid);
                }
            }
        }
        public async Task<List<CheckUserVoteDetailDto>> CheckUserVote(int userid,int pollid ,int responseid)
        {
            return await _repository.CheckUser(userid,pollid,responseid);
        }
    }
}
