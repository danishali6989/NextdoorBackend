using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IHostingEnvironment _environment;

        public BookmarkController(IBookmarkManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
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
                if(model.Postid !=0 && model.Categoryid!=0 && model.Pollid==0 && model.Eventid==0 )
                {

                }
                await _manager.AddAsync(model);
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
        public async Task<IActionResult> GetAllAsync()
        {


            return Ok(await _manager.GetAllAsync());
        }

        /*[HttpGet]
        [Route("get-all-bookmark-by-userid")]
        public async Task<IActionResult> GetAllAsyncByUserId(int userid)
        {


            return Ok(await _manager.GetAllAsyncByUserId(userid));
        }*/
    }
}
