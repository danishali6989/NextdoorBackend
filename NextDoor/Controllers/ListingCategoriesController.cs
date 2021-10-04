using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.ListingCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ListingCategoriesController : ControllerBase
    {
        private readonly IListingCategoriesManager _manager;
        private readonly IHostingEnvironment _environment;

        public ListingCategoriesController(IListingCategoriesManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }


        [HttpPost]
        //  [Authorize]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] ListingCategoriesAddModel model)
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

            return Ok("EventCategory Added");
        }


        [HttpPost]
        // [Authorize]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] ListingCategoriesAddModel model)
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

            return Ok("EventCategory Updated");
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

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            await _manager.DeleteAsync(id);

            return Ok("Deleted");
        }


        [HttpGet]

        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {


            return Ok(await _manager.GetAllAsync());
        }

    }
}
