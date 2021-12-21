using NextDoor.Dtos.Poll;
using NextDoor.Entities;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IPollRepository
    {
        Task AddPollAsync(Poll entity);
        Task AddPollUserVoteAsync(CheckUserVote entity);
        Task<PollDetailDto> PollDetail(int user_id);
        Task AddPollMultimediaAsync(PollMultimedia entity);
        Task AddOptionDetailAsync(PolOption entity);
        //get polresponse data
        Task<PolOption> GetAsync(int id);

        Task<List<PollDetailDto>> getpollbypollid(int pollid);
        //edit count
        void Edit(PolOption entity);

        //get poll response
        Task<List<PollOptionDetailDto>> GetAllOption(int pollid);
        Task<List<PollDetailDto>> GetAllPoll();
        Task<List<PollDetailDto>> GetPollDetail(int id);
        Task<List<PollOptionDto>> getPollOptionByPoll(int id);
        Task<List<PollComment>> getPollCommentByid(int id);
        Task<List<PollLikes>> getPolllikesById(int id);
        Constants.ReactionStatus getPollLikesReactionByUserId(int userid, int pollid);
        Task DeletePoll(int id);
        Task deletemultimedia(int id);
        Task deleteOption(int id);
        Task<List<PollMultimediDto>> getPollMultimediByPoll(int id);
        Task<List<CheckUserVoteDetailDto>> CheckUser(int userid,int pollid,int responseid);
        /* Task AddPersonDetailAsync(Person entity);
         Task AddVechileDetailAsync(VechileSafety entity);

         Task<List<PostDetailDto>> GetAllByCategoryAsync(int categoryId);*/
    }
}
