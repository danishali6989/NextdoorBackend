using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
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
   //[Produces("application/json")]
    [ApiController]
    public class NextDoorUserLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly INextDoorUserLoginManager _manager;
        private readonly IHostingEnvironment _environment;

        public NextDoorUserLoginController(IConfiguration configuration ,INextDoorUserLoginManager manager, IHostingEnvironment environment)
        {

            _configuration = configuration;
            _manager = manager;
            _environment = environment;
        }


        [HttpPost]
        [Route("NextDoorUserLogin")]
        public async Task<IActionResult> Login([FromBody]NextDoorUserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            var login = new NextDoorUserLoginModel();
            login.UserName = model.UserName;
            login.Password = model.Password;

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(login);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

             var url = "http://172.248.67.186:80/api/UserLogin/NextDoorUserlogin";
            //var url = "https://localhost:44308/api/UserLogin/NextDoorUserlogin";

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
                        return Ok(result);
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

          //  var url = "https://localhost:44308/api/UserLogin/logout/" + id;

            var url = "http://172.248.67.186:80/api/UserLogin/logout/" + id;
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


        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> NextDoorChangePassword([FromBody] ChangePasswordModel model)
        {

             var data = await _manager.isExist(model.Userid);
            if (data!=null)
            {
                var data1 = new
                {
                    Userid = model.Userid,
                    oldpassword = model.oldPassword,
                   
                };

                string ApiResponse = "";
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data1);
                var data2 = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://172.248.67.186:80/api/UserLogin/checkpassword";
               // var url = "https://localhost:44308/api/UserLogin/checkpassword";


                using var client = new HttpClient();
                var response = await client.PostAsync(url, data2);
                ApiResponse = response.Content.ReadAsStringAsync().Result;

                string result = response.Content.ReadAsStringAsync().Result;
                if (result != $"\"valid old password\"")
                {
                    return BadRequest("Invalid Password");
                }
                else
                {
                    var data4 = new 
                    {
                        Userid = model.Userid,
                        Newpassword = model.NewPassword
                    };
                    string ApiResponse1 = "";
                    var json1 = Newtonsoft.Json.JsonConvert.SerializeObject(data4);
                    var data5 = new System.Net.Http.StringContent(json1, Encoding.UTF8, "application/json");
                    var url2 = "http://172.248.67.186:80/api/UserLogin/nxtchangePassword";
                   // var url2 = "https://localhost:44308/api/UserLogin/nxtchangePassword";


                    using var client1 = new HttpClient();
                    var response1 = await client1.PostAsync(url2, data5);
                    ApiResponse1 = response.Content.ReadAsStringAsync().Result;

                    string result1 = response.Content.ReadAsStringAsync().Result;
                    if (result1 != $"\"password change\"")
                    {
                        return BadRequest("failed");
                    }
                    else
                    {
                        return Ok("password change");
                    }
                }
            }
            else
            {
                return BadRequest("Record not exist");
            }
            

           // return Ok("Password Change");

        }
    }

    
}
