using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Comment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _manager;
        private readonly ILikeManager _Likemanager;
        private readonly IHostingEnvironment _environment;

        public CommentController(ICommentManager manager,ILikeManager likeManager,
            IHostingEnvironment environment)
        {
            _Likemanager = likeManager ;
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        //  [Authorize]
        [Route("AddComment")]
        public async Task<IActionResult> Add([FromBody] CommentAddModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {

                CommentAddModel cmnt = new CommentAddModel();
                /* Post.Id = data.Id;
                 Post.User_Id = data.User_id;
                 Post.CategoryId = data.Category_id;*/
                cmnt.User_Id = model.User_Id;
                cmnt.PostId = model.PostId;
                cmnt.EventId = model.EventId;
                cmnt.Comment_Parent_Id = model.Comment_Parent_Id;
                cmnt.CommentText = model.CommentText;
                cmnt.Lan = model.Lan;
                cmnt.Lat = model.Lat;
                cmnt.File1 = model.File1;
                cmnt.File2 = model.File2;
                cmnt.File3 = model.File3;


                cmnt.FileUrl1 = model.FileUrl1;
                cmnt.FileUrl2 = model.FileUrl2;
                cmnt.FileUrl3 = model.FileUrl3;

                string extensions;
               

                if (cmnt.File1 != null && cmnt.File1 != "string")
                {
                    var myfilename = string.Format(@"{0}", Guid.NewGuid());
                    var data = cmnt.File1.Substring(0, 5);
                    switch (data.ToUpper())
                    {
                        case "IVBOR":
                            cmnt.Extension1 = ".jpg";
                            cmnt.MediaType1 = "image";
                            extensions = "jpg";
                            break;
                        
                        case "/9J/4":
                            cmnt.Extension1 = ".png";
                            cmnt.MediaType1 = "image";
                            extensions = "png";
                            break;
                        
                        case "AAAAI":
                            cmnt.Extension1 = ".mp4";
                            cmnt.MediaType1 = "video";
                            extensions = "mp4";
                            break;
                        
                        default:
                            cmnt.Extension1 = ".jpeg";
                            cmnt.MediaType1 = "image";
                            extensions = "jpeg";
                            break;
                    }
                  
                    if(extensions != "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath,"Attachment", "image");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension1;

                        string filename = "image/" + myfilename + cmnt.Extension1;

                        var bytess = Convert.FromBase64String(cmnt.File1);
                        cmnt.FileUrl1 = filename;
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }
                    
                    else if (extensions == "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath,"Attachment", "Videos");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension1;

                        string filename = "Videos/" + myfilename + cmnt.Extension1;

                        var bytess = Convert.FromBase64String(cmnt.File1);
                        cmnt.FileUrl1 = filename;
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                }
               
                if (cmnt.File2 != null && cmnt.File2 != "string")
                {
                    var myfilename = string.Format(@"{0}", Guid.NewGuid());
                    var data = cmnt.File2.Substring(0, 5);
                    switch (data.ToUpper())
                    {
                        case "IVBOR":
                            cmnt.Extension2 = ".jpg";
                            cmnt.MediaType2 = "image";
                            extensions = "jpg";
                            break;

                        case "/9J/4":
                            cmnt.Extension2 = ".png";
                            cmnt.MediaType2 = "image";
                            extensions = "png";
                            break;

                        case "AAAAI":
                            cmnt.Extension2 = ".mp4";
                            cmnt.MediaType2 = "video";
                            extensions = "mp4";
                            break;

                        default:
                            cmnt.Extension2 = ".jpeg";
                            cmnt.MediaType2 = "image";
                            extensions = "jpeg";
                            break;
                    }

                        if (extensions != "mp4")
                        {
                            string uploadsFolder = Path.Combine(_environment.WebRootPath,"Attachment", "image");

                            string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension2;

                            string filename = "image/" + myfilename + cmnt.Extension2;
                            cmnt.FileUrl2 = filename;

                        var bytess = Convert.FromBase64String(cmnt.File2);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                        }

                        else if (extensions == "mp4")
                        {
                            string uploadsFolder = Path.Combine(_environment.WebRootPath,"Attachment", "Videos");

                            string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension2;

                            string filename = "Videos/" + myfilename + cmnt.Extension2;
                            cmnt.FileUrl2 = filename;

                          var bytess = Convert.FromBase64String(cmnt.File2);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                        }

                }
               
                if (cmnt.File3 != null && cmnt.File3 != "string")
                {
                    var myfilename = string.Format(@"{0}", Guid.NewGuid());
                    var data = cmnt.File3.Substring(0, 5);
                    switch (data.ToUpper())
                    {
                        case "IVBOR":
                            cmnt.Extension3 = ".jpg";
                            cmnt.MediaType3 = "image";
                            extensions = "jpg";
                            break;

                        case "/9J/4":
                            cmnt.Extension3 = ".png";
                            cmnt.MediaType3 = "image";
                            extensions = "png";
                            break;

                        case "AAAAI":
                            cmnt.Extension3 = ".mp4";
                            cmnt.MediaType3 = "video";
                            extensions = "mp4";
                            break;

                        default:
                            cmnt.Extension3 = ".jpeg";
                            cmnt.MediaType3 = "image";
                            extensions = "jpeg";
                            break;
                    }

                    if (extensions != "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath,"Attachment", "image");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension3;

                        string filename = "image/" + myfilename + cmnt.Extension3;

                        var bytess = Convert.FromBase64String(cmnt.File3);
                        cmnt.FileUrl3 = filename;
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                    else if (extensions == "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath,"Attachment", "Videos");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension3;

                        string filename = "Videos/" + myfilename + cmnt.Extension3;

                        var bytess = Convert.FromBase64String(cmnt.File3);
                        cmnt.FileUrl3 = filename;
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                }


                await _manager.AddAsync(cmnt);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Comment Added");
        }



        [HttpPost]
        [Route("Edit-Comment")]
        public async Task<IActionResult> EditComment([FromBody]CommentEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            
            try
            {
                CommentEditModel cmnt = new CommentEditModel();
                /* Post.Id = data.Id;
                 Post.User_Id = data.User_id;
                 Post.CategoryId = data.Category_id;*/
                cmnt.Id = model.Id;
                cmnt.User_Id = model.User_Id;
                cmnt.PostId = model.PostId;
                cmnt.EventId = model.EventId;
                cmnt.Comment_Parent_Id = model.Comment_Parent_Id;
                cmnt.CommentText = model.CommentText;
               
                cmnt.File1 = model.File1;
                cmnt.File2 = model.File2;
                cmnt.File3 = model.File3;


                cmnt.FileUrl1 = model.FileUrl1;
                cmnt.FileUrl2 = model.FileUrl2;
                cmnt.FileUrl3 = model.FileUrl3;

                string extensions;

                if (cmnt.File1 != null && cmnt.File1 != "string")
                {
                    var myfilename = string.Format(@"{0}", Guid.NewGuid());
                    var data = cmnt.File1.Substring(0, 5);
                    switch (data.ToUpper())
                    {
                        case "IVBOR":
                            cmnt.Extension1 = ".jpg";
                            cmnt.MediaType1 = "image";
                            extensions = "jpg";
                            break;

                        case "/9J/4":
                            cmnt.Extension1 = ".png";
                            cmnt.MediaType1 = "image";
                            extensions = "png";
                            break;

                        case "AAAAI":
                            cmnt.Extension1 = ".mp4";
                            cmnt.MediaType1 = "video";
                            extensions = "mp4";
                            break;

                        default:
                            cmnt.Extension1 = ".jpeg";
                            cmnt.MediaType1 = "image";
                            extensions = "jpeg";
                            break;
                    }

                    if (extensions != "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension1;

                        string filename = "image/" + myfilename + cmnt.Extension1;

                        var bytess = Convert.FromBase64String(cmnt.File1);
                        cmnt.FileUrl1 = filename;
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                    else if (extensions == "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Videos");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension1;

                        string filename = "Videos/" + myfilename + cmnt.Extension1;

                        var bytess = Convert.FromBase64String(cmnt.File1);
                        cmnt.FileUrl1 = filename;
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                }

                if (cmnt.File2 != null && cmnt.File2 != "string")
                {
                    var myfilename = string.Format(@"{0}", Guid.NewGuid());
                    var data = cmnt.File2.Substring(0, 5);
                    switch (data.ToUpper())
                    {
                        case "IVBOR":
                            cmnt.Extension2 = ".jpg";
                            cmnt.MediaType2 = "image";
                            extensions = "jpg";
                            break;

                        case "/9J/4":
                            cmnt.Extension2 = ".png";
                            cmnt.MediaType2 = "image";
                            extensions = "png";
                            break;

                        case "AAAAI":
                            cmnt.Extension2 = ".mp4";
                            cmnt.MediaType2 = "video";
                            extensions = "mp4";
                            break;

                        default:
                            cmnt.Extension2 = ".jpeg";
                            cmnt.MediaType2 = "image";
                            extensions = "jpeg";
                            break;
                    }

                    if (extensions != "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension2;

                        string filename = "image/" + myfilename + cmnt.Extension2;
                        cmnt.FileUrl2 = filename;

                        var bytess = Convert.FromBase64String(cmnt.File2);
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                    else if (extensions == "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Videos");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension2;

                        string filename = "Videos/" + myfilename + cmnt.Extension2;
                        cmnt.FileUrl2 = filename;

                        var bytess = Convert.FromBase64String(cmnt.File2);
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                }

                if (cmnt.File3 != null && cmnt.File3 != "string")
                {
                    var myfilename = string.Format(@"{0}", Guid.NewGuid());
                    var data = cmnt.File3.Substring(0, 5);
                    switch (data.ToUpper())
                    {
                        case "IVBOR":
                            cmnt.Extension3 = ".jpg";
                            cmnt.MediaType3 = "image";
                            extensions = "jpg";
                            break;

                        case "/9J/4":
                            cmnt.Extension3 = ".png";
                            cmnt.MediaType3 = "image";
                            extensions = "png";
                            break;

                        case "AAAAI":
                            cmnt.Extension3 = ".mp4";
                            cmnt.MediaType3 = "video";
                            extensions = "mp4";
                            break;

                        default:
                            cmnt.Extension3 = ".jpeg";
                            cmnt.MediaType3 = "image";
                            extensions = "jpeg";
                            break;
                    }

                    if (extensions != "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension3;

                        string filename = "image/" + myfilename + cmnt.Extension3;

                        var bytess = Convert.FromBase64String(cmnt.File3);
                        cmnt.FileUrl3 = filename;
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                    else if (extensions == "mp4")
                    {
                        string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Videos");

                        string filepath = uploadsFolder + "/" + myfilename + cmnt.Extension3;

                        string filename = "Videos/" + myfilename + cmnt.Extension3;

                        var bytess = Convert.FromBase64String(cmnt.File3);
                        cmnt.FileUrl3 = filename;
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }

                }
                await _manager.EditAsync(cmnt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("comment Edited");
        }
       
        
        
        
        [HttpGet]
        [Route("get-all-Comment-By-PostId")]
        public async Task<IActionResult> GetAllAsync(int postId)
        {

            var data = await _manager.GetAllCommentByPostIdAsync(postId);
          //  var data1 = 

            foreach (var r in data)
            {
                var replies = await _manager.GetAllCommentByIdAsync(r.Id);
                r.replies = replies;
                r.likes= await _Likemanager.GetAllLikesByCommentIdAsync(r.Id);  //comment id name change karna hai
                if (r.replies.Count > 0)
                {
                    foreach(var item in r.replies)
                    {
                        var innerReplies = await _manager.GetAllCommentByIdAsync(item.Id);
                        item.replies = innerReplies;
                        item.likes = await _Likemanager.GetAllLikesByCommentIdAsync(item.Id);
                    }
                }

            }
            var result = new
            {
                StatusCode = 200,
                comments = data ,
              //  likes = data1
            };
            return Ok(result);
        }


        [HttpPost]
        [Route("Delete-Comment")]
        public async Task<IActionResult> Delete(int Commentid)
        {


            await _manager.DeleteAsync(Commentid);

            return Ok("Comment Deleted");
        }
    }
}
