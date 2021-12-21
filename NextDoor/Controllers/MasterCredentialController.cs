using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.MasterCre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    
    [ApiController]
    public class MasterCredentialController : ControllerBase
    {

        private readonly IMasterCredentialManager _manager;
        private readonly IHostingEnvironment _environment;


        public MasterCredentialController(IMasterCredentialManager manager, IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("addMasterCredential")]
        public async Task<IActionResult> Add([FromBody] AddMasterModel model)
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

            return Ok("MasterCredential Added");
        }
    }
}
