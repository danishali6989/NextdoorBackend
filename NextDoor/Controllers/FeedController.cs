using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextDoor.Infrastructure.Managers;
using NextDoor.Dtos;
using NextDoor.Dtos.Post;
using NextDoor.Dtos.Event;
using NextDoor.Dtos.Poll;
using NextDoor.Dtos.Feeds;
using Microsoft.AspNetCore.Hosting;

namespace NextDoor.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IPostManager _postManager;
        private readonly IEventManager _eventManager;
        private readonly IPollManager _pollManager;
       
        public FeedController(IPostManager postManager,
            IEventManager eventManager, IPollManager pollManager)
        {
            _postManager = postManager;
            _eventManager = eventManager;
            _pollManager = pollManager;
          
        }

        [HttpGet]
        [Route("get-all-feeds")]
        public async Task<IActionResult> GetAllAsync(int userid)
        {
            List<PostDetailDto> posts = await _postManager.GetAllPostAsync(userid);
            List<EventDetailDto> events = await _eventManager.EventGetAllAsync(userid);
            List<PollDetailDto> polls = await _pollManager.PollGetAllAsync(userid);
            posts = posts.OrderBy(x => x.CreatedOn).ToList();
            events = events.OrderBy(x => x.CreatedOn).ToList();
            polls = polls.OrderBy(x => x.CreatedOn).ToList();
            List<feedDto> feeds = new List<feedDto>();
            foreach (var item in posts)
            {
                var feed = new feedDto()
                {
                    posttype = "Post",
                    Id = item.Id,
                    User_id = item.User_id,
                    Category_id = item.Category_id,
                    Category_Name = item.CategoryName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Listing_CategoryId = item.Listing_CategoryId,
                    Listing_Category_Name = item.listingcategoryname,
                    SafetyDescription = item.SafetyDescription,
                    SafetyPersonDescription = item.SafetyPersonDescription,
                    Bookmark = item.Bookmark,
                    Subject = item.Subject,
                    Message = item.Message,
                    lan = item.lan,
                    lat = item.lat,
                    Price = item.Price,
                    Status = item.Status,
                    CreatedOn = item.CreatedOn,
                    persons = item.persons,
                    vehicles = item.vehicles,
                    postmultimedia = item.multimedia,
                    PostMultimediaCount = item.multimediaCount,
                    postComments = item.postcomments,
                    PostCommentCount = item.PostCommentCount,
                    Postlikes = item.postlikes,
                    postAllLikes = item.postlikes.Count,
                    UserReaction_Id = item.Reaction_Id,
                    ShareCount = item.PostShareCount,
                    BookmarkId = item.Bookmarkid
                };
                feeds.Add(feed);
            }
            foreach (var item in events)
            {
                var feed = new feedDto()
                {
                    posttype = "Event",
                    Id = item.ID,
                    EventID = item.ID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    EventCategory_id = item.EventCategory_Id,
                    EventCategoryName = item.EventCategoryName,
                    User_id = item.User_ID,
                    EventBookmark = item.EventBookmark,
                    Title = item.Title,
                    Description = item.Description,
                    Attachmentfile = item.Attachmentfile,
                    Address = item.Address,
                    StartDate = item.StartDate,
                    StartTime = item.StartTime,
                    EndDate = item.EndDate,
                    EndTime = item.EndTime,
                    CreatedOn = item.CreatedOn,
                    EventStatus = item.Status,
                    eventComments = item.eventcomments,
                    EventCommentCount = item.EventCommentCount,
                    eventLike = item.eventlikes,
                    eventLikes = item.eventlikes.Count,
                    UserReaction_Id = item.UserReaction_Id,
                    ShareCount = item.EventShareCount,
                    BookmarkId = item.BookmarkId
                };
                feeds.Add(feed);
           
            }

            foreach (var item in polls)
            {
                var feed = new feedDto()
                {
                    posttype="Poll",
                    Id = item.Poll_Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PollId = item.Poll_Id,
                    User_id = item.User_id,
                    PollBookmark = item.PollBookmark,
                    Question = item.Question,
                    Description = item.Description,
                    PollStatus = item.Status,
                    options = item.options,
                    multimedia = item.multimedia,
                    PollMultimedia = item.MultimediaCount,
                    pollComments = item.pollcomment,
                    PollCommentCount = item.PollCommentCount,
                    pollLike = item.polllike,
                    pollLikes = item.polllike.Count,
                    UserReaction_Id = item.UserReaction_id,
                    ShareCount=item.PollShareCount,
                    CreatedOn = item.CreatedOn,
                    BookmarkId = item.Bookmarkid
                };
                feeds.Add(feed);
            }
            
            feeds = feeds.OrderByDescending(x => x.CreatedOn).ToList();
            return Ok(feeds);

        }
    }
}
