using NextDoor.Dtos.Poll;
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
    public class PollRepository : IPollRepository
    {
        private readonly DataContext _dataContext;
        public PollRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddPollAsync(Poll entity)
        {
            await _dataContext.Poll.AddAsync(entity);
        }
        public async Task AddPollUserVoteAsync(CheckUserVote entity)
        {
            await _dataContext.CheckUserVote.AddAsync(entity);
        }

        public async Task<PollDetailDto> PollDetail(int user_id)
        {
            return await (from s in _dataContext.Poll
                          where s.UserID == user_id 
                          select new PollDetailDto
                          {
                              Poll_Id = s.Id,
                              User_id = s.UserID,
                              Question = s.Question,
                              Description = s.Description,
                               Status = s.Status,
                          })
                          .AsNoTracking().OrderBy(s => s.Poll_Id)
                          .LastOrDefaultAsync();
        }
        public async Task AddPollMultimediaAsync(PollMultimedia entity)
        {
            await _dataContext.PollMultimedia.AddAsync(entity);
        }

        public async Task AddOptionDetailAsync(PolOption entity)
        {
            await _dataContext.PolOption.AddAsync(entity);
        }

        public async Task<PolOption> GetAsync(int id)
        {
            return await _dataContext.PolOption.FindAsync(id);
        }
        public async Task<Poll> GetPollDetailAsync(int Pollid)
        {
            return await _dataContext.Poll.FindAsync(Pollid);
        }
        public async Task AddShareUserDetailsAsync(ShareDetail entity)
        {
            await _dataContext.ShareDetail.AddAsync(entity);
        }
        public void Edit(PolOption entity)
        {
            _dataContext.PolOption.Update(entity);
        }
        public void EditSharePost(Poll entity)
        {
            _dataContext.Poll.Update(entity);
        }
        public async Task<List<PollOptionDetailDto>> GetAllOption(int pollid)
        {
            return await (from s in _dataContext.PolOption
                          where s.Poll_id == pollid

                          select new PollOptionDetailDto
                          {
                              Id = s.Id,
                              User_id = s.User_id,
                              Poll_id = s.Poll_id,
                              OptionName = s.Option_Name,
                              count = s.Count,
                              CreatedOn = s.CreatedOn
                          })
                          .AsNoTracking()
                          .ToListAsync();

        }
        public async Task<List<PollDetailDto>> GetAllPoll()
        {
            return await (from s in _dataContext.Poll
                          select new PollDetailDto
                          {
                              Poll_Id = s.Id,
                              FirstName = s.NextDoorUser.FirstName,
                              LastName = s.NextDoorUser.LastName,
                              PollBookmark = s.PollBookmark,
                              User_id = s.UserID,
                              Question = s.Question,
                              Description = s.Description,
                              Status = s.Status,
                              CreatedOn = s.CreatedOn,
                              PollShareCount = s.PollShareCount
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<PollDetailDto>> GetAllPollBookmark(int userid)
        {
            return await (from s in _dataContext.Poll
                          where s.PollBookmark==true && s.UserID== userid
                          select new PollDetailDto
                          {
                              Poll_Id = s.Id,
                              PollBookmark = s.PollBookmark,
                              User_id = s.UserID,
                              Question = s.Question,
                              Description = s.Description,
                              Status = s.Status,
                              CreatedOn = s.CreatedOn
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<List<PollDetailDto>> getpollbypollid(int pollid)
        {
            return await (from s in _dataContext.Poll
                          where s.Id == pollid
                          select new PollDetailDto
                          {
                              Poll_Id = s.Id,
                              User_id = s.UserID,
                              Question = s.Question,
                              Description = s.Description,
                              Status = s.Status,
                              CreatedOn = s.CreatedOn
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<List<PollDetailDto>> GetPollDetail(int id)
        {
            return await (from s in _dataContext.Poll
                              where s.Id == id

                          select new PollDetailDto
                          {
                              Poll_Id = s.Id,
                              User_id = s.UserID,
                              Question = s.Question,
                              Description = s.Description,
                              Status = s.Status,
                              CreatedOn = s.CreatedOn

                          })
                          .AsNoTracking()
                          .ToListAsync();

        }
        public async Task<List<PollComment>> getPollCommentByid(int Id)
        {
            return await (from s in _dataContext.Comment
                          where s.Poll_id == Id && s.CommentParent_Id == 0
                          select new PollComment
                          {
                              id = s.Id,
                              User_id = s.User_id,
                              FirstName = s.NextDoorUser.FirstName,
                              LastName = s.NextDoorUser.LastName,
                              Pollid = s.Poll_id,
                              CommentParent_Id = s.CommentParent_Id,
                              CommentText = s.CommentText,
                              Attachment1 = s.Attachment1,
                              Attachment2 = s.Attachment2,
                              Attachment3 = s.Attachment3,
                              lat = s.lat,
                              lng = s.lng,

                          })
                          .OrderByDescending(x=> x.id)
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<PollLikes>> getPolllikesById(int Id)
        {
            return await (from s in _dataContext.Likes
                          where s.Poll_id == Id && s.Comment_id == 0
                          select new PollLikes
                          {
                              Comment_id = s.Comment_id,
                              Reaction_Id = s.Reaction_Id,
                              User_id = s.User_id,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public Constants.ReactionStatus getPollLikesReactionByUserId(int userid, int pollid)
        {
            var obj = _dataContext.Likes.Where(x => x.User_id == userid && x.Poll_id == pollid && x.Comment_id == 0).FirstOrDefault();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.Reaction_Id;

            }
        }
        public async Task<List<PollOptionDto>> getPollOptionByPoll(int id)
        {
            try
            {
                var data = await (from s in _dataContext.PolOption
                                  where s.Poll_id == id
                                  select new PollOptionDto
                                  {
                                      pollid = s.Poll_id,
                                      optionId = s.Id,
                                      OptionName = s.Option_Name,
                                      count = s.Count
                                  }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletePoll (int id)
        {
            var data = await _dataContext.Poll.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Poll.Update(data);
        }
       
        public async Task deletemultimedia(int id)
        {
            var data1 = _dataContext.PollMultimedia.Where(x => x.Polld == id).FirstOrDefault();
            _dataContext.PollMultimedia.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task deleteOption(int id)
        {
            var data1 = _dataContext.PolOption.Where(x => x.Poll_id == id).FirstOrDefault();
            _dataContext.PolOption.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        
        public async Task<List<PollMultimediDto>> getPollMultimediByPoll(int id)
        {
            try
            {
                var data = await (from s in _dataContext.PollMultimedia
                                  where s.Polld == id
                                  select new PollMultimediDto
                                  {
                                      pollid = s.Polld,
                                      AttachmentType = s.AtachmentType,
                                      Attachment = s.Atachments
                                  }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CheckUserVoteDetailDto>> CheckUser(int userid, int pollid, int responseid)
        {
            try
            {


                var data = await (from s in _dataContext.CheckUserVote
                                  where s.Poll_Id == pollid && s.User_Id == userid && s.Response_Id == responseid
                                  select new CheckUserVoteDetailDto
                                  {
                                      Id = s.Id,
                                      User_Id = s.User_Id,
                                      Poll_Id = s.Poll_Id,
                                      Response_Id = s.Response_Id,
                                      CreatedOn = s.CreatedOn,

                                  })
                              .AsNoTracking()
                              .ToListAsync();
                return data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
