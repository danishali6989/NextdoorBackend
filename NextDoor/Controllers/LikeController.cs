using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Likes;
using System;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeManager _manager;
        private readonly IHostingEnvironment _environment;

        public LikeController(ILikeManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] LikesAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {

                if (model.Post_id > 0 && model.Reaction_Id>0 && model.Comment_id==0 && model.Event_id==0 && model.Poll_id == 0)                //Post like
                {
                    var data = await _manager.CheckUserLike(model.User_id, model.Post_id);
                    
                    if (data == null)
                    {
                     await _manager.AddAsync(model);
                    }
                    else if (model.Post_id > 0 && model.Reaction_Id > 0 && model.Event_id == 0 && model.Poll_id ==0)            //edit post reaction
                    {
                        await _manager.EditLikeReaction(model.User_id, model.Post_id, model.Reaction_Id);
                        return Ok("Post Like Edited");
                    }
                    else
                    {
                        await _manager.DeleteLike(model.User_id,model.Post_id);
                        return Ok("Post Like Deleted");
                    }

                }
               
                else if (model.Post_id > 0 && model.Reaction_Id > 0 && model.Comment_id > 0 && model.Event_id ==0 && model.Poll_id == 0)   //Post comment Like
                {
                    var data = await _manager.CheckPostCommentLike(model.User_id, model.Post_id,model.Comment_id);

                    if (data == null)
                    {
                        await _manager.AddAsync(model);
                        return Ok("Postcomment like added ");
                    }
                    else if (model.Post_id > 0 && model.Reaction_Id > 0 && model.Comment_id > 0 && model.Event_id == 0 && model.Poll_id == 0)            //edit post comment reaction
                    {
                        await _manager.EditCommentLikeReaction(model.User_id, model.Post_id, model.Comment_id, model.Reaction_Id);
                        return Ok("Postcomment like edited ");
                    }
                    else
                    {
                        await _manager.DeleteCommentLike(model.User_id, model.Post_id,model.Comment_id);
                        return Ok("Postcomment like Deleted ");
                    }
                }
               
                else if(model.Event_id > 0 && model.Comment_id==0 && model.Post_id==0 && model.Poll_id ==0)                                    //Event Like
                {
                    var data = await _manager.CheckEventUserLike(model.User_id, model.Event_id);
                    if (data == null)
                    {
                        await _manager.AddAsync(model);
                        return Ok("Event like added ");
                    }
                    else if (model.Event_id > 0 && model.Reaction_Id > 0 && model.Post_id == 0 && model.Poll_id==0)        //edit event reaction
                    {
                        await _manager.EditEventLikeReaction(model.User_id, model.Event_id, model.Reaction_Id);
                        return Ok("Event like edited ");
                    }
                    else
                    {
                        await _manager.DeleteEventLike(model.User_id, model.Event_id);          //delete event like 
                        return Ok("Event like Deleted ");
                    }

                }
              
                else if (model.Event_id > 0 && model.Comment_id >0 && model.Post_id == 0 && model.Poll_id==0)             //Event Comment Like
                {
                    var data = await _manager.CheckEventCommentLike(model.User_id, model.Event_id,model.Comment_id);
                    if (data == null)
                    {
                        await _manager.AddAsync(model);
                        return Ok("Eventcomment like added ");
                    }
                    else if (model.Event_id > 0 && model.Reaction_Id > 0 && model.Comment_id > 0 && model.Post_id == 0 && model.Poll_id == 0)        //edit event comment reaction
                    {
                        await _manager.EditEventCommentLikeReaction(model.User_id, model.Event_id, model.Comment_id, model.Reaction_Id);
                        return Ok("Eventcomment like edited ");
                    }
                    else
                    {
                        await _manager.DeleteEventCommentLike(model.User_id, model.Event_id,model.Comment_id);
                        return Ok("Eventcomment like Deleted ");
                    }
                }
               
                else if(model.Poll_id > 0 && model.Comment_id == 0 && model.Post_id == 0 && model.Event_id ==0)
                {
                    var data1 = await _manager.CheckPollUserLike(model.User_id, model.Poll_id);
                    if (data1 == null)
                    {
                        await _manager.AddAsync(model);
                        return Ok("Poll like added ");
                    }
                    else if (model.Poll_id > 0 && model.Reaction_Id > 0 && model.Post_id == 0 && model.Event_id == 0)        //edit event reaction
                    {
                        await _manager.EditPollLikeReaction(model.User_id, model.Poll_id, model.Reaction_Id);
                        return Ok("Poll like edited ");
                    }
                    else
                    {
                        await _manager.DeletePollLike(model.User_id, model.Poll_id);          //delete event like 
                        return Ok("Poll like Deleted ");
                    }
                }

                else if (model.Poll_id > 0 && model.Comment_id > 0 && model.Post_id == 0 && model.Event_id == 0)             //Event Comment Like
                {
                    var data1 = await _manager.CheckPollCommentLike(model.User_id, model.Poll_id, model.Comment_id);
                    if (data1 == null)
                    {
                        await _manager.AddAsync(model);
                        return Ok("Pollcomment like added ");
                    }
                    else if (model.Poll_id > 0 && model.Reaction_Id > 0 && model.Comment_id > 0 && model.Post_id == 0 && model.Event_id == 0)        //edit event comment reaction
                    {   
                        await _manager.EditPollCommentLikeReaction(model.User_id, model.Event_id, model.Comment_id, model.Reaction_Id);
                        return Ok("Pollcomment like edited ");
                    }
                    else
                    {
                        await _manager.DeletePollCommentLike(model.User_id, model.Poll_id, model.Comment_id);
                        return Ok("Pollcomment like Deleted ");
                    }
                }
                else
                {
                    return BadRequest("Invalid Enteries");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Like Added");
        }


            [HttpGet]
        [Route("get-all-Likes-By-UserId")]
        public async Task<IActionResult> GetAllAsync(int userId)
        {

            var data = await _manager.GetAllByUserIdAsync(userId);
            return Ok(data);
           
        }
    }
}
