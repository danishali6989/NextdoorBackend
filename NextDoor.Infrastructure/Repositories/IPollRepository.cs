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
        Task<PolOption> GetAsync(int id);
        Task<Poll> GetPollDetailAsync(int Pollid);
        Task<List<PollDetailDto>> getpollbypollid(int pollid);
        void Edit(PolOption entity);
        void EditSharePost(Poll entity);
        Task AddShareUserDetailsAsync(ShareDetail entity);


        Task<List<PollOptionDetailDto>> GetAllOption(int pollid);
        Task<List<PollDetailDto>> GetAllPoll();
        Task<List<PollDetailDto>> GetAllPollBookmark(int userid);
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
    }
}
