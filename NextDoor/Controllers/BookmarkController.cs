using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Dtos.Event;
using NextDoor.Dtos.Feeds;
using NextDoor.Dtos.Poll;
using NextDoor.Dtos.Post;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Bookmark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkManager _manager;
        private readonly IPostManager _postManager;
        private readonly IPollManager _pollManager;
        private readonly IEventManager _eventManager;
      

        public BookmarkController(IBookmarkManager manager, IPostManager postmanager, IPollManager pollmanager, IEventManager eventmanager)
        
        {
            _postManager = postmanager;
            _pollManager = pollmanager;
            _eventManager = eventmanager;
            _manager = manager;
          
        }


        [HttpPost]
        //  [Authorize]
        [Route("AddBookmark")]
        public async Task<IActionResult> Add([FromBody] AddBookmarkModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                if(model.userid !=0  )
                {

                 await _manager.AddAsync(model);
                }
                else
                {
                    return BadRequest("userid required");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Bookmark Added");
        }


        [HttpPost]
        [Route("deletebookmark/{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            await _manager.DeleteAsync(id);

            return Ok("Bookmark Deleted");
        }

        [HttpGet]
        [Route("get-all-bookmark")]
        public async Task<IActionResult> GetAllAsync(int userid)
        {
            List<PostDetailDto> posts = await _postManager.GetAllBookmarkPostAsync(userid);
            List<EventDetailDto> events = await _eventManager.EventGetAllBookmarkAsync(userid);
            List<PollDetailDto> polls = await _pollManager.PollGetAllBookmarkAsync(userid);
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
                    posttype = "Poll",
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
                    UserPollReaction_Id = item.UserReaction_id,

                    CreatedOn = item.CreatedOn
                };
                feeds.Add(feed);
            }
            feeds = feeds.OrderByDescending(x => x.CreatedOn).ToList();
            return Ok(feeds);

         
        }

       
    }
}
