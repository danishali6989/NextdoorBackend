using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Location;
using NextDoor.Models.Neigbourhood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodController : ControllerBase
    {
        private readonly INeighbourhoodManager _manager;
        private readonly IJoinNeighbourhoodManager _joinmanager;
        public NeighbourhoodController(INeighbourhoodManager manager,
            IJoinNeighbourhoodManager joinmanager)
        {
            _manager = manager;
            _joinmanager = joinmanager;
        }
      
        
        [HttpPost]
        [Route("addNeighbourhood")]
        public async Task<IActionResult> Add([FromBody] NeighbourhoodAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.AddAsync(model);
                var data = await _manager.GetDetail(model.userid);
                NeighbourhoodAddModel join = new NeighbourhoodAddModel();
                join.userid = data.userid;
                join.id = data.id;
                await _joinmanager.JoinAsync(join);
                if (model.location != null)
                {
                    foreach (var a in model.location)
                    {
                        if (a!=null) 
                        {
                            AddLocationModel location1 = new AddLocationModel();
                            location1.userid = data.userid;
                            location1.NeighbourhoodId = data.id;
                            location1.lat = a.lat;
                            location1.lng = a.lng;
                            await _manager.AddLocation(location1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Neighbourhood Added");
        }


        [HttpPost]
        [Route("editNeighbourhood")]
        public async Task<IActionResult> Edit([FromBody] NeighbourhoodAddModel model)
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

            return Ok("Neighbourhood Updated");
        }


        [HttpGet]
        [Route("get-detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var data = await _manager.GetDetailAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);
            return Ok("Neighbourhood Deleted");
        }


        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _manager.GetAllAsync());
        }

        
    }
}
