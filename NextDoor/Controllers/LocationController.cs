using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationManager _manager;
       // private readonly IHostingEnvironment _environment;


        public LocationController(ILocationManager manager)
        {
            _manager = manager;
           // _environment = environment;
        }

        [HttpPost]
        [Route("addNeighbourhoodLocation")]
        public async Task<IActionResult> Add([FromBody] AddLocationModel model)
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

            return Ok("Neighbourhood Location Added");
        }
    }
}
