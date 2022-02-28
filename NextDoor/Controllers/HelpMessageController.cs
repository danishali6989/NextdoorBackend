using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.HelpMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpMessageController : ControllerBase
    {
        private readonly IHelpMapManager _manager;
        public HelpMessageController(IHelpMapManager manager)
        {
            _manager = manager;
        }
        
        [HttpPost]
        [Route("AddHelpMessage")]
        public async Task<IActionResult> Add([FromBody]AddHelpMapModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                if (model.lat!=0 && model.lng!=0 && model.UserId!=0 && model.Message!= null)
                {
                   await _manager.AddMessage(model); 
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Message Added");
        }
       
        [HttpPost]
        [Route("ReplyHelpMessage")]
        public async Task<IActionResult> Reply([FromBody] AddHelpMapModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                if ( model.UserId != 0 && model.Message != null)
                {
                    await _manager.AddMessage(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Reply Added");
        }
       
        
        [HttpPost]
        [Route("EditHelpMessage")]
        public async Task<IActionResult> Edit([FromBody]EditHelpMapModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.EditAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("HelpMessage Edited");
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _manager.GetAllAsync());
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);

            return Ok("Deleted");
        }

    }
}
