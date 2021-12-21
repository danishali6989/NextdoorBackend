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
        //PostManager postManager = new PostManager();
        //EventManager eventManager = new EventManager();
        //PollManager pollManager = new PollManager();
        private readonly IPostManager _postManager;
        private readonly IEventManager _eventManager;
        private readonly IPollManager _pollManager;
        private readonly IHostingEnvironment _environment;
        public FeedController(IPostManager postManager,
            IEventManager eventManager, IPollManager pollManager, IHostingEnvironment environment)
        {
            _postManager = postManager;
            _eventManager = eventManager;
            _pollManager = pollManager;
            _environment = environment;
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
            string path = _environment.WebRootPath;
           
            foreach (var item in posts)
            {
                var feed = new feedDto()
                {
                    posttype = "Post",

                    Id = item.Id,
                    
                    User_id = item.User_id,
                    Category_id = item.Category_id,
                    Category_Name = item.CategoryName,
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
                    postComments = item.postcomments,
                    Postlikes = item.postlikes,
                    postAllLikes = item.postlikes.Count,
                    UserReaction_Id = item.Reaction_Id
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
                    eventLike = item.eventlikes,
                    eventLikes = item.eventlikes.Count,
                    UserReaction_Id = item.UserReaction_Id,
                    
                };
                feeds.Add(feed);
            }

            foreach (var item in polls)
            {
                var feed = new feedDto()
                {
                    posttype="Poll",
                    Id = item.Poll_Id,
                    PollId = item.Poll_Id,
                    User_id = item.User_id,
                    PollBookmark = item.PollBookmark,
                    Question = item.Question,
                    // response_id = ,
                    Description = item.Description,
                    PollStatus = item.Status,
                    options = item.options,
                    multimedia = item.multimedia,
                    pollComments = item.pollcomment,
                    pollLike = item.polllike,
                    pollLikes = item.polllike.Count,


                    CreatedOn = item.CreatedOn
                };
                feeds.Add(feed);
            }

            feeds = feeds.OrderByDescending(x => x.CreatedOn).ToList();
            return Ok(feeds);

        }
    }
}
