using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupManager _manager;
        public GroupController(IGroupManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] GroupAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.AddAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Group Added");
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit(GroupEditModel  model)
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

            return Ok("Group Edited");
        }

        [HttpGet]
        [Route("Getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await _manager.GetAllAsync());
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
