using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Event;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Event;
using NextDoor.Models.Post;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
   public class EventManager :IEventManager 
    {

        private readonly IEventRepository _repository;
        private readonly IBookmarkRepository _Bookmarkrepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentRepository _Commentrepository;
        private readonly ILikeRepository _likerepository;

        private readonly string _userId;

        public EventManager(IHttpContextAccessor contextAccessor, ICommentRepository commentRepository,
          ILikeRepository likerepository, IBookmarkRepository bookmarkRepository,
          IEventRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _Commentrepository = commentRepository;
            _likerepository = likerepository;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _Bookmarkrepository = bookmarkRepository;
        }

        public async Task EventEditAsync(EventAddModel model)
        {
            var item = await _repository.geteventdetail(model.Id);
            EventFactory.CreateEditEvent(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteEventAsync(int eventid)
        {
            await _repository.DeleteEvent(eventid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddImageAsync(AddImageModel model)
        {
            await _repository.AddImageAsync(EventFactory.CreateImage(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddShare(SharePostAddModel model)
        {
            var item = await _repository.geteventdetail(model.Eventid);
            EventFactory.CreateCount(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
            await _repository.AddShareUserDetailsAsync(PostFactory.CreateShareDetails(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddEventAsync(EventAddModel model)
        {
            await _repository.AddEventAsync(EventFactory.CreateEvent(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<ImageDetailDto>> ImageGetAllAsync()
        {
            return await _repository.ImageGetAllAsync();
        }

        public async Task<List<EventDetailDto>> EventGetAllAsync(int userid)
        {
            
            var data = await _repository.EventGetAllAsync();
            
            foreach (var item in data)                                      // for events
            {
                item.eventcomments = await _repository.getEventCommentByid(item.ID);        //for event comments
                item.EventCommentCount = item.eventcomments.Count;
                item.eventlikes = await _repository.getEventlikesById(item.ID);
                item.UserReaction_Id =  _repository.getEventLikesReactionById(userid,item.ID);
                item.BookmarkId = _Bookmarkrepository.GetEventBookmarkId(item.ID);
                foreach (var r in item.eventcomments)                               // for comments replies
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.like = likes;
                    r.likes = likes.Count;
                   
                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)                                        // for inner replies
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.likes = Commentlikes;
                            item1.Commentlikes = Commentlikes.Count;
                            
                            
                        }   
                    }
                }
            }

            return data;
        }

        public async Task<List<EventDetailDto>> EventGetAllBookmarkAsync(int userid)
        {

            var data = await _repository.EventGetAllBookmarkAsync(userid);

            foreach (var item in data)                                      // for events
            {
                item.eventcomments = await _repository.getEventCommentByid(item.ID);        //for event comments
                item.eventlikes = await _repository.getEventlikesById(item.ID);
                item.UserReaction_Id = _repository.getEventLikesReactionById(userid, item.ID);
                foreach (var r in item.eventcomments)                               // for comments replies
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.like = likes;
                    r.likes = likes.Count;

                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)                                        // for inner replies
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.likes = Commentlikes;
                            item1.Commentlikes = Commentlikes.Count;
                        }
                    }
                }
            }

            return data;
        }

        public async Task<List<EventDetailDto>> EventGetAllAsync()
        {
            var data = await _repository.EventGetAllAsync();
            foreach (var item in data)                                      // for events
            {
                item.eventcomments = await _repository.getEventCommentByid(item.ID);        //for event comments
                item.eventlikes = await _repository.getEventlikesById(item.ID);
                foreach (var r in item.eventcomments)                               // for comments replies
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.like = likes;
                    r.likes = likes.Count;

                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)                                        // for inner replies
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.likes = Commentlikes;
                            item1.Commentlikes = Commentlikes.Count;
                        }
                    }
                }
            }

            return data;
        }


        public async Task<List<EventDetailDto>> GetEventByEventId(int eventid)
        {
            var data = await _repository.geteventbyeventid(eventid);
            foreach (var item in data)
            {
                item.eventcomments = await _repository.getEventCommentByid(item.ID);        //for event comments
                item.eventlikes = await _repository.getEventlikesById(item.ID);
                foreach (var r in item.eventcomments)                               // for comments replies
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.like = likes;
                    r.likes = likes.Count;
                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)                                        // for inner replies
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.likes = Commentlikes;
                            item1.Commentlikes = Commentlikes.Count;
                        }
                    }
                }
            }
            return data;
        }
    }
}
