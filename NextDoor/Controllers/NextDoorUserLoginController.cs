using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NextDoor.Models.NextDoorUserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class NextDoorUserLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
      //  private readonly INextDoorUserLoginManager _manager;

        public NextDoorUserLoginController(IConfiguration configuration) //INextDoorUserLoginManager manager)
        {

            _configuration = configuration;
            //_manager = manager;
        }


        [HttpPost]
        [Route("NextDoorUserlogin")]
        public async Task<IActionResult> Login(NextDoorUserLoginModel model)
        {


            var login = new NextDoorUserLoginModel();
            login.UserName = model.UserName;
            login.Password = model.Password;

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(login);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44308/api/UserLogin/Userlogin";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("CompanyId", "1");


            try
            {
            var response = await client.PostAsync(url, data);
                if (response.ReasonPhrase == "OK")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    if (result != "")
                    {
                        return Ok("user Login");
                    }
                    else
                    {
                        return BadRequest("Invalid UserName");
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                  
                    if (result == $"\"Invalid UserName\"")
                    {
                        return BadRequest("Invalid UserName");
                    }
                    else
                    {
                        if(result == $"\"Already Login\"")
                        {
                            return BadRequest("Already Login");
                        }
                        else
                        {
                            if (result == $"\"Invalid Password\"")
                            {
                                return BadRequest("Invalid PassWord");
                            }
                        }
                    }

                    return BadRequest("Already login");
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        //    [Authorize]
        [Route("logout/{id}")]
        public async Task<IActionResult> LogOut(int id)
        {

            
          //  var header = Request.Headers["CompanyId"];
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(id);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44308/api/UserLogin/logout/"+id;
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("CompanyId", "1");

            try
            {
                var response = await client.PostAsync(url, data);
                if (response.ReasonPhrase == "OK")
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    if (result == "")
                    {
                        return Ok("logout");
                    }
                    else
                    {
                        return BadRequest("invalid operation");
                    }

                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return BadRequest("Not LogOut");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            
        }

    }
}
