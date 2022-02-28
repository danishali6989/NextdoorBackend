using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Poll;
using NextDoor.Models.Post;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PollController : ControllerBase
    {

        private readonly IPollManager _manager;
        private readonly IHostingEnvironment _environment;

        public PollController(IPollManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }


        [HttpPost]
        [Route("AddPoll")]
        public async Task<IActionResult> Add([FromBody] PollAddModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }


            if (model.Question != null && model.Question != "string")
            {
               await _manager.AddPollAsync(model);
            }
            else
            {
                return BadRequest("Question required");
            }
            //get data from Poll
            var data = await _manager.PollDetail(model.UserID);

            PollAddModel poll = new PollAddModel();
            poll.Id           = data.Poll_Id;
            poll.UserID       = data.User_id;
            poll.image        = model.image;
            poll.video        = model.video;
            poll.FileUrl      = model.FileUrl;

            try
            {
                string extensions;
                string extension;

                if (poll.image != null)
                {

                    foreach (var file in poll.image)
                    {
                        if (file != "string" && file != "" && file != null)
                        {
                            var data1 = file.Substring(0, 5);
                            switch (data1.ToUpper())
                            {
                                case "IVBOR":
                                    extension = ".jpg";
                                    poll.MediaType = "image";
                                    extensions = "jpg";
                                    break;

                                case "/9J/4":
                                    extension = ".png";
                                    poll.MediaType = "image";
                                    extensions = "png";
                                    break;

                                case "AAAAI":
                                    extension = ".mp4";
                                    poll.MediaType = "video";
                                    extensions = "mp4";
                                    break;

                                default:
                                    extension = ".jpeg";
                                    poll.MediaType = "image";
                                    extensions = "jpeg";
                                    break;
                            }

                            if (extensions != "mp4")
                            {
                                var myfilename = string.Format(@"{0}", Guid.NewGuid());

                                var fileExtension = Path.GetExtension(myfilename);

                                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                                string filepath = uploadsFolder + "/" + myfilename + extension;

                                string filename = "image/" + myfilename + extension;

                                var bytess = Convert.FromBase64String(file);
                                using (var imageFile = new FileStream(filepath, FileMode.Create))
                                {
                                    imageFile.Write(bytess, 0, bytess.Length);
                                    imageFile.Flush();
                                }
                                poll.FileUrl = filename;
                                poll.MediaType = "Image";
                                poll.FileData = file;

                                //add Images/Video to PollMultimedia
                                await _manager.AddPollMultimediaAsync(poll);
                            }
                        }
                    }
                }

                if (poll.video != null)
                {
                    foreach (var file in poll.video)
                    {
                        if (file != "string" && file != "" && file != null)
                        {
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Videos");

                            string filepath = uploadsFolder + "/" + myfilename + ".mp4";

                            string filename = "Videos/" + myfilename + ".mp4";

                            var bytess = Convert.FromBase64String(file);
                            using (var videoFile = new FileStream(filepath, FileMode.Create))
                            {
                                videoFile.Write(bytess, 0, bytess.Length);
                                videoFile.Flush();
                            }
                            poll.FileUrl = filename;
                            poll.MediaType = "Video";
                            poll.FileData = file;
                            //add Images/Video to PollMultimedia
                            await _manager.AddPollMultimediaAsync(poll);

                        }
                    }
                }
                try
                {
                    if (model.Option.Count > 1)
                    {

                        foreach (var res in model.Option)
                        {
                            AddPollOptionModel choice = new AddPollOptionModel();
                            choice.poll_id = data.Poll_Id;
                            choice.user_id = data.User_id;
                            choice.OptionName = res.OptionName;

                            await _manager.AddOptionDetailAsync(choice);
                        }
                    }
                    else
                    {
                        return BadRequest("You Must Add atleast two Responses to your Poll");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Poll Added");
        }



        [HttpPost]
        [Route("Vote")]
        public async Task<IActionResult> Vote([FromBody] VoteAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                var data = await _manager.CheckUserVote(model.User_id,model.Poll_id,model.ResponseId);
                if (data.Count == 0)
                {
                    await _manager.AddVoteAsync(model);

                }
                else
                {
                    return BadRequest("Vote Already Added");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var options = await _manager.GetAllOptionAsync(model.Poll_id);
            var result = new
            {
                StatusCode = 200,
                vote = options,
            };
            return Ok(result);

        }

        [HttpPost]
        [Route("SharePoll")]
        public async Task<IActionResult> AddShare([FromBody] SharePostAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            if (model.Userid != 0 && model.Pollid != 0)
            {
                await _manager.AddShare(model);
            }
            else
            {
                return BadRequest("value required");
            }
            return Ok("Poll Shared");
        }

        [HttpGet]
        [Route("get-all-poll")]
        public async Task<IActionResult> GetAllPollAsync(int userid)
        {


            return Ok(await _manager.PollGetAllAsync(userid));
        }


        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);

            return Ok("Poll Deleted");
        }
    }

}
