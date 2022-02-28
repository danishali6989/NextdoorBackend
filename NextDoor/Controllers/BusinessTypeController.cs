using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.BusinessType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessTypeController : ControllerBase
    {
        public readonly IBusinessTypeManager _manager;
        public BusinessTypeController(IBusinessTypeManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("AddBusinessType")]
        public async Task<IActionResult> Add(AddBusinessTypeModel model)
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
            return Ok("BusinessType Added");
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(AddBusinessTypeModel model)
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
            return Ok("BusinessType Edited");
        }

        [HttpGet]
        [Route("getdetail-By-Id")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await _manager.GetDetail(id));
        }

        [HttpPost]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _manager.GetAllAsync());
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Deleted");
        }
    }
}
