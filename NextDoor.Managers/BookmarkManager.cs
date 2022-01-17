using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Bookmark;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Bookmark;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public class BookmarkManager : IBookmarkManager
    {
        private readonly IBookmarkRepository _repository;
        private readonly IPostRepository _repository1;
        private readonly ICommentRepository _Commentrepository;
        private readonly ILikeRepository _likerepository;
        private readonly IEventRepository _eventrepository;
        private readonly IPollRepository _pollrepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public BookmarkManager(IHttpContextAccessor contextAccessor,
          IBookmarkRepository repository,IPostRepository repository1, IEventRepository eventRepository,
          IUnitOfWork unitOfWork, IPollRepository pollrepository, ICommentRepository Commentrepository)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _eventrepository = eventRepository;
            _pollrepository = pollrepository;
            _repository = repository;
            _Commentrepository = Commentrepository;
            _repository1 = repository1;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddBookmarkModel model)
        {
            await _repository.AddBookmark(BookmarkFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();
            if (model.Postid > 0)
            {
                await _repository.AddBookmarkPost(model.Postid);
            }
            else if (model.Eventid > 0)
            {
                await _repository.AddBookmarkEventt(model.Eventid);
            }
            else if (model.Pollid > 0)
            {
                await _repository.AddBookmarkPoll(model.Pollid);
            }
            
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteBookmark(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<BookmarkDetailDto>> GetAllAsync()
        {
           // return await _repository.GetAllBookmarkAsync();

            var data = await _repository.GetAllBookmarkAsync();

            foreach (var a in data) 
            {
                if (a.postid > 0)
                {
                    var data1 = await _repository1.getpostbypostid(a.postid);
                    foreach (var item in data1)
                    {
                        
                        item.persons = await _repository1.getPeronsbyid(item.Id);
                        item.vehicles = await _repository1.getVehiclebyid(item.Id);
                        item.multimedia = await _repository1.getPostMultimediaByPostid(item.Id);

                        item.postlikes = await _repository1.getPostlikesById(item.Id);
                        //  item.Reaction_Id = _repository1.getPostLikesReactionByUserId(userid, item.Id);
                        if (item.postcomments != null)
                        {


                            foreach (var r in item.postcomments)
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
                    }
                    
                }
                else if (a.eventid > 0)
                {
                    var data1 = await _eventrepository.geteventbyeventid(a.eventid);
                    foreach (var h in data1)
                    {


                        h.eventcomments = await _eventrepository.getEventCommentByid(h.ID);        //for event comments
                        h.eventlikes = await _eventrepository.getEventlikesById(h.ID);
                       // h.UserReaction_Id = _eventrepository.getEventLikesReactionById(userid, item.ID);
                        foreach (var r in h.eventcomments)                               // for comments replies
                        {
                            var replies = await _Commentrepository.GetAllCommentById(r.id);
                            r.replies = replies;
                            var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                            r.like = likes;
                            r.likes = likes.Count;
                            // var readctionId = await _likerepository.GetAllLikesByCommentId(r.id);
                            // r.Reaction_Id = ;

                            if (r.replies.Count > 0)
                            {
                                foreach (var item1 in r.replies)                                        // for inner replies
                                {
                                    var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                                    item1.replies = innerReplies;
                                    //item1.likes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                                    var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                                    item1.likes = Commentlikes;
                                    item1.Commentlikes = Commentlikes.Count;


                                }
                            }
                        }
                    }
                }
                else if (a.pollid > 0)
                {
                    var data2 = await _pollrepository.getpollbypollid(a.pollid);
                    foreach (var item2 in data2)
                    {
                        item2.multimedia = await _pollrepository.getPollMultimediByPoll(item2.Poll_Id);
                        item2.options = await _pollrepository.getPollOptionByPoll(item2.Poll_Id);
                    }
                }

            }
            return data;
        }

    }
}
