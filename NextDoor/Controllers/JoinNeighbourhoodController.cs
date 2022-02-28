using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.JoinNeighbourhood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Infrastructure.Managers;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JoinNeighbourhoodController : ControllerBase
    {
        private readonly IJoinNeighbourhoodManager _manager;
        private readonly INextDoorUserManager _nxtusermanager;
        private readonly INeighbourhoodManager _neighbourhoodManager; 
        public JoinNeighbourhoodController(IJoinNeighbourhoodManager manager
            , INextDoorUserManager nxtusermanager, INeighbourhoodManager neighbourhoodManager)
        {
            _manager = manager;
            _nxtusermanager = nxtusermanager;
            _neighbourhoodManager = neighbourhoodManager;
        }

        [HttpPost]
        [Route("JoinNeighbourhood")]
        public async Task<IActionResult> Add([FromBody] JoinNeighbourhoodAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                var user = await _nxtusermanager.CheckNextDoorUser(model.UserId);
                var neighbour = await _neighbourhoodManager.GetDetailAsync(model.NeighbourhoodId);
                if (user.PostalCode == neighbour.PostalCode)
                {
                     await _manager.AddAsync(model);
                }
                else
                {
                    return BadRequest("not allowed to join");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Neighbourhood join");
        }
    }
}
