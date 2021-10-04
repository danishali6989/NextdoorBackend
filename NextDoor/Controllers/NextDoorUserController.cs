﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Models.NextDoorUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Infrastructure.Managers;

namespace NextDoor.Controllers
{


    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class NextDoorUserController : ControllerBase
    {

        private readonly INextDoorUserManager _manager;
        private readonly IHostingEnvironment _environment;

        public NextDoorUserController(INextDoorUserManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }


        [HttpPost]
        //  [Authorize]
        [Route("SignUpNextDoorUser")]
        public async Task<IActionResult> Add([FromBody] AddNextDoorUserModel model)

        {
            var header = Request.Headers["CompanyId"].ToString();

            if (header == "")
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            /*
                        if (await _manager.CheckNextDoorUserEmail(model.Email) != null)
                        {
                            return BadRequest("Email Already SS Exist");
                        }*/

            try
            {
               
                var data = new
                {
                    FirstName = model.Usr_FName,
                    LastName = model.Usr_LName,
                    UserName = model.Email,
                    Email = model.Email,
                    Password = model.Password,
                    Mobile = "98747563214",
                    Ip_Address = "23.36.54.2",
                    Finance_year = 2021,
                    App_id = 1,
                    RoleId = 3,
                    image = "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",
                    imageUrl = "",
                   
                };


                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var data1 = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44308/api/User/addy";
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("CompanyId","1");

                var response = await client.PostAsync(url, data1);


                string result = response.Content.ReadAsStringAsync().Result;
                model.UserId = Convert.ToInt32(result);
                await _manager.AddAsync(model,header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("NextDoorUser Created");

        }
    }
}
