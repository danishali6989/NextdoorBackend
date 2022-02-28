using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Event;
using NextDoor.Models.Post;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventManager _manager;
        private readonly IHostingEnvironment _environment;

        public EventController(IEventManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }



        [HttpPost]
        [Route("addimage")]
        public async Task<IActionResult> Add([FromBody] AddImageModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            

            try
            {
                if (model.image != null )
                {

                    //this is a simple white background image
                    var myfilename = string.Format(@"{0}", Guid.NewGuid());

                    var fileExtension = Path.GetExtension(myfilename);

                    string uploadsFolder =  Path.Combine(_environment.WebRootPath,"Attachment", "image");

                    string filepath = uploadsFolder + "/" + myfilename + ".jpeg";

                    string filename = "image/" + myfilename + ".jpeg";

                    var bytess = Convert.FromBase64String(model.image);
                    using (var imageFile = new FileStream(filepath, FileMode.Create))
                    {
                        imageFile.Write(bytess, 0, bytess.Length);
                        imageFile.Flush();
                    }
                    model.FileUrl = filename;
                    model.MediaType = "Image";
                   // model.FileData = file;
                    //add Images/Video to Multimedia
                    await _manager.AddImageAsync(model);
                }
                else
                {
                    return BadRequest("no image");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Image Added");

        }

        [HttpPost]
        [Route("ShareEvent")]
        public async Task<IActionResult> AddShare([FromBody] SharePostAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            if (model.Userid != 0 && model.Eventid != 0)
            {
                await _manager.AddShare(model);
            }
            else
            {
                return BadRequest("value required");
            }
            return Ok("Event Shared");
        }
       
        
        [HttpGet]
        [Route("get-all-image")]
        public async Task<IActionResult> GetAllImageAsync()
        {
            return Ok(await _manager.ImageGetAllAsync());
        }

        [HttpGet]
        [Route("get-all-event")]
        public async Task<IActionResult> GetAllEventAsync()
        {
            return Ok(await _manager.EventGetAllAsync());
        }


        [HttpPost]
        [Route("AddEvent")]
        public async Task<IActionResult> AddEventAsync([FromBody] EventAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                if ((model.EventCategory_id != 0 || model.EventCategory_id != null)  &&model.Address!=null && model.StartDate != null && model.StartTime != null && model.Title != null )
                {
                    if (model.image != "string")
                    {
                        var myfilename = string.Format(@"{0}", Guid.NewGuid());

                        var fileExtension = Path.GetExtension(myfilename);

                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                        string filepath = uploadsFolder + "/" + myfilename + ".jpeg";

                        string filename = "image/" + myfilename + ".jpeg";

                        var bytess = Convert.FromBase64String(model.image);
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                        model.FileUrl = filename;

                    }
                    await _manager.AddEventAsync(model);

                }
                else
                {
                    return BadRequest("enter desired values");
                }

            }
            catch
            {
                Exception ex;
            }
            return Ok("Event Added");
        }
       
        
        [HttpPost]
        [Route("Edit-Event")]
        public async Task<IActionResult> Edit([FromBody] EventAddModel model)
        {

            try
            {
                if ((model.EventCategory_id != 0 || model.EventCategory_id != null) && model.Address != null && model.StartDate != null && model.StartTime != null && model.Title != null)
                {
                    if(model.image != "string"&& model.image != "")
                    {
                        var myfilename = string.Format(@"{0}", Guid.NewGuid());

                        var fileExtension = Path.GetExtension(myfilename);

                        string uploadsFolder = Path.Combine(_environment.WebRootPath,"Attachment", "image");

                        string filepath = uploadsFolder + "/" + myfilename + ".jpeg";

                        string filename = "image/" + myfilename + ".jpeg";

                        var bytess = Convert.FromBase64String(model.image);
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                        model.FileUrl = filename;

                    }

                    await _manager.EventEditAsync(model);

                }
                else
                {
                    return BadRequest("enter required values");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Event Updated");
        }

        [HttpPost]
        [Route("deleteEvent")]
        public async Task<IActionResult> Delete(int id)
        {


            await _manager.DeleteEventAsync(id);

            return Ok("EventDeleted");
        }

        [HttpPost]
        [Route("get-by-eventId")]
        public async Task<IActionResult> getEventbyeventid(int eventid)
        {
            return Ok(await _manager.GetEventByEventId(eventid));
        }
    }
}
