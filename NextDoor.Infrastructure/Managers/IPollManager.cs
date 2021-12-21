using NextDoor.Dtos.Poll;
using NextDoor.Models.Poll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IPollManager
    {
        Task AddPollAsync(PollAddModel model);
        Task<PollDetailDto> PollDetail(int user_id);
        Task AddPollMultimediaAsync(PollAddModel model);

        //Add vote
        Task AddVoteAsync(VoteAddModel model);

        Task AddOptionDetailAsync(AddPollOptionModel model);

        Task<List<PollOptionDetailDto>> GetAllOptionAsync(int pollid);
        Task<List<PollDetailDto>> PollGetAllAsync(int userid);
        Task DeleteAsync(int id);
        Task<List<CheckUserVoteDetailDto>> CheckUserVote(int userid,int pollid,int responseid);

    }
}
