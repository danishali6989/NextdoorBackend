using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NextDoor.Dtos.Post;
using NextDoor.Entities;
using NextDoor.Helpers;
using NextDoor.Infrastructure.Managers;
using NextDoor.Models.Post;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NextDoor.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private readonly IPostManager _manager;
        private readonly IHostingEnvironment _environment;

        public PostController(IPostManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        [Route("SharePost")]
        public async Task<IActionResult> AddShare([FromBody] SharePostAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            
            if(model.Userid !=0 && model.Postid != 0)
            {
                await _manager.AddShare(model);
            }
            else
            {
                return BadRequest("value required");
            }
            return Ok("Post Shared");
        }

        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> Add([FromBody] PostAddModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            if (model.CategoryId != 0 && model.CategoryId != null)
            {


                if (model.Subject != null && model.Subject != "string" && model.Subject != "")
                {
                    //add data to Post
                    await _manager.AddPostAsync(model);
                }
                else
                {
                    return BadRequest("Subject Required");
                }
            }
            else
            {
                return BadRequest("category required");
            }

            //get data from post
            var data = await _manager.PostDetail(model.UserId);

            PostAddModel Post = new PostAddModel();
            Post.Id = data.Id;
            Post.UserId = data.User_id;
            Post.CategoryId = data.Category_id;
            Post.image =  model.image;
            Post.video = model.video;
            Post.document = model.document;
            Post.free = ((model.free == 0) ? 0 : 1);
            Post.FileUrl = model.FileUrl;

            try
            {
                string extensions;
                string extension;


                if (Post.image != null )
                {
                    foreach (var file in Post.image)
                    {
                        if (file != null && file != "string" && file != "")
                        {
                            var data1 = file.Substring(0, 5);
                            switch (data1.ToUpper())
                            {
                                case "IVBOR":
                                    extension = ".jpg";
                                    Post.MediaType = "image";
                                    extensions = "jpg";
                                    break;

                                case "/9J/4":
                                    extension = ".png";
                                    Post.MediaType = "image";
                                    extensions = "png";
                                    break;

                                case "AAAAI":
                                    extension = ".mp4";
                                    Post.MediaType = "video";
                                    extensions = "mp4";
                                    break;

                                default:
                                    extension = ".jpeg";
                                    Post.MediaType = "image";
                                    extensions = "jpeg";
                                    break;
                            }

                            if (extensions != ".mp4" && extensions != ".pdf")
                            {
                                var myfilename = string.Format(@"{0}", Guid.NewGuid());

                                var fileExtension = Path.GetExtension(myfilename);

                                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                                string filepath = uploadsFolder + "/" + myfilename + extension;

                                string filename = "image/" + myfilename + extension;

                                var bytess = Convert.FromBase64String(file);
                                using (var imageFile = new FileStream(filepath, FileMode.Create))
                                {
                                    imageFile.Write(bytess, 0, bytess.Length);
                                    imageFile.Flush();
                                }
                                Post.FileUrl = filename;
                                Post.MediaType = "Image";
                                Post.FileData = file;
                                //add Images/Video to Multimedia
                                await _manager.AddMultimediaAsync(Post);
                            }
                        }
                    }
                }

                if (Post.video != null && model.CategoryId !=2)
                {
                    foreach (var file in Post.video)
                    {
                        if (file != null && file != "string" && file != "")
                        {
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Videos");

                            string filepath = uploadsFolder + "/" + myfilename + ".mp4";

                            string filename = "Videos/" + myfilename + ".mp4";

                            var bytess = Convert.FromBase64String(file);
                            using (var videoFile = new FileStream(filepath, FileMode.Create))
                            {
                                videoFile.Write(bytess, 0, bytess.Length);
                                videoFile.Flush();
                            }
                            Post.FileUrl = filename;
                            Post.MediaType = "Video";
                            Post.FileData = file;
                            //add Images/Video to Multimedia
                            await _manager.AddMultimediaAsync(Post);

                        }
                    }
                }

                // for document category
                if (Post.document != null && model.CategoryId != 2)
                {
                    foreach (var file in Post.document)
                    {
                        if (file != null && file != "string" && file != "")
                        {
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Document");

                            string filepath = uploadsFolder + "/" + myfilename + ".pdf";

                            string filename = "Document/" + myfilename + ".pdf";

                            var bytess = Convert.FromBase64String(file);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                            Post.FileUrl = filename;
                            Post.MediaType = "Document";
                            Post.FileData = file;
                            //add Images/Video/Document to Multimedia
                            await _manager.AddMultimediaAsync(Post);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Post Added");
        }


      
        
        [HttpPost]
        [Route("editFindsPost")]
        public async Task<IActionResult> EditFinds([FromBody] PostFindsEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.PostFindsEdit(model);

                PostFindsEditModel Post = new PostFindsEditModel();
                Post.Id = model.Id;
                Post.UserId = model.UserId;
                Post.CategoryId = model.CategoryId;
                Post.Listing_CategoryId = model.Listing_CategoryId;
                Post.image = model.image;
                Post.oldImage = model.oldImage;
                Post.free = ((model.free == 0) ? 0 : 1);
                Post.FileUrl = model.FileUrl;

                var data = await _manager.getpostmultimedia(model.Id, model.UserId);

                foreach (var s in data)
                {
                    await _manager.Deletemultimedia(s.Id);
                }

                if (Post.oldImage != null)
                {

                    foreach (var r in Post.oldImage)
                    {
                        if (r != "string" && r != "")
                        {

                            Post.FileUrl = r;
                            Post.MediaType = "image";
                            await _manager.AddMultimediaAsync(Post);
                        }
                    }
                }

                try
                {
                    string extensions;
                    string extension;


                    if (Post.image != null)
                    {
                        foreach (var file in Post.image)
                        {
                            if (file != null && file != "string" && file != "")
                            {
                                var data1 = file.Substring(0, 5);
                                switch (data1.ToUpper())
                                {
                                    case "IVBOR":
                                        extension = ".jpg";
                                        Post.MediaType = "image";
                                        extensions = "jpg";
                                        break;

                                    case "/9J/4":
                                        extension = ".png";
                                        Post.MediaType = "image";
                                        extensions = "png";
                                        break;

                                    case "AAAAI":
                                        extension = ".mp4";
                                        Post.MediaType = "video";
                                        extensions = "mp4";
                                        break;

                                    default:
                                        extension = ".jpeg";
                                        Post.MediaType = "image";
                                        extensions = "jpeg";
                                        break;
                                }

                                if (extensions != ".mp4" && extensions != ".pdf")
                                {
                                    var myfilename = string.Format(@"{0}", Guid.NewGuid());

                                    var fileExtension = Path.GetExtension(myfilename);

                                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                                    string filepath = uploadsFolder + "/" + myfilename + extension;

                                    string filename = "image/" + myfilename + extension;

                                    var bytess = Convert.FromBase64String(file);
                                    using (var imageFile = new FileStream(filepath, FileMode.Create))
                                    {
                                        imageFile.Write(bytess, 0, bytess.Length);
                                        imageFile.Flush();
                                    }
                                    Post.FileUrl = filename;
                                    Post.MediaType = "Image";
                                    Post.FileData = file;
                                    await _manager.AddMultimediaAsync(Post);

                                    //add Images/Video to Multimedia
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Finds Post Edited");
        }


        [HttpPost]
        [Route("editPost")]
        public async Task<IActionResult> Edit([FromBody] PostEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.PostEdit(model);

                    PostEditModel Post = new PostEditModel();
                    Post.Id = model.Id;
                    Post.UserId = model.UserId;
                    Post.CategoryId = model.CategoryId;
                    Post.image = model.image;
                Post.oldImage = model.oldImage;
                Post.oldVideo = model.oldVideo;
                Post.oldDocument = model.oldDocument;
                    Post.video = model.video;
                    Post.document = model.document;
                    Post.free = ((model.free == 0) ? 0 : 1);
                    Post.FileUrl = model.FileUrl;
                   
                    var data = await _manager.getpostmultimedia(model.Id,model.UserId);
             
               foreach (var s in data)
                    {
                        await _manager.Deletemultimedia(s.Id);
                    }
                
                if (Post.oldImage != null )
                {

                    foreach (var r in Post.oldImage)
                    {
                        if(r!= "string" && r!= "")
                        {

                        Post.FileUrl = r;
                        Post.MediaType = "image";
                        await _manager.AddMultimediaAsync(Post);
                        }
                    }
                }
                if (Post.oldVideo != null)
                {
                    foreach (var o in Post.oldVideo)
                    {
                        if (o != "string" && o != "")
                        {
                            Post.FileUrl = o;
                            Post.MediaType = "video";
                            await _manager.AddMultimediaAsync(Post);
                        } 
                    }
                }
                if (Post.oldDocument != null)
                {
                    foreach (var p in Post.oldDocument)
                    {
                        if (p != "string" && p != "")
                        {
                            Post.FileUrl = p;
                            Post.MediaType = "document";
                            await _manager.AddMultimediaAsync(Post);
                        }
                    }
                }


                try
                {
                    string extensions;
                    string extension;


                    if (Post.image != null)
                    {
                        foreach (var file in Post.image)
                        {
                            if (file != null && file != "string" && file != "")
                            {
                                var data1 = file.Substring(0, 5);
                                switch (data1.ToUpper())
                                {
                                    case "IVBOR":
                                        extension = ".jpg";
                                        Post.MediaType = "image";
                                        extensions = "jpg";
                                        break;

                                    case "/9J/4":
                                        extension = ".png";
                                        Post.MediaType = "image";
                                        extensions = "png";
                                        break;

                                    case "AAAAI":
                                        extension = ".mp4";
                                        Post.MediaType = "video";
                                        extensions = "mp4";
                                        break;

                                    default:
                                        extension = ".jpeg";
                                        Post.MediaType = "image";
                                        extensions = "jpeg";
                                        break;
                                }

                                if (extensions != ".mp4" && extensions != ".pdf")
                                {
                                    var myfilename = string.Format(@"{0}", Guid.NewGuid());

                                    var fileExtension = Path.GetExtension(myfilename);

                                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                                    string filepath = uploadsFolder + "/" + myfilename + extension;

                                    string filename = "image/" + myfilename + extension;

                                    var bytess = Convert.FromBase64String(file);
                                    using (var imageFile = new FileStream(filepath, FileMode.Create))
                                    {
                                        imageFile.Write(bytess, 0, bytess.Length);
                                        imageFile.Flush();
                                    }
                                    Post.FileUrl = filename;
                                    Post.MediaType = "Image";
                                    Post.FileData = file;
                                    await _manager.AddMultimediaAsync(Post);

                                    //add Images/Video to Multimedia
                                }
                            }

                        }
                    }

                    if (Post.video != null)
                    {
                        foreach (var file in Post.video)
                        {
                            if (file != null && file != "string" && file != "")
                            {
                                var myfilename = string.Format(@"{0}", Guid.NewGuid());

                                var fileExtension = Path.GetExtension(myfilename);

                                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Videos");

                                string filepath = uploadsFolder + "/" + myfilename + ".mp4";

                                string filename = "Videos/" + myfilename + ".mp4";

                                var bytess = Convert.FromBase64String(file);
                                using (var videoFile = new FileStream(filepath, FileMode.Create))
                                {
                                    videoFile.Write(bytess, 0, bytess.Length);
                                    videoFile.Flush();
                                }
                                Post.FileUrl = filename;
                                Post.MediaType = "Video";
                                Post.FileData = file;
                                //add Images/Video to Multimedia
                                await _manager.AddMultimediaAsync(Post);

                            }
                        }
                    }

                    // for document category
                    if (Post.document != null)
                    {
                        foreach (var file in Post.document)
                        {
                            if (file != null && file != "string" && file != "")
                            {
                                var myfilename = string.Format(@"{0}", Guid.NewGuid());

                                var fileExtension = Path.GetExtension(myfilename);

                                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Document");

                                string filepath = uploadsFolder + "/" + myfilename + ".pdf";

                                string filename = "Document/" + myfilename + ".pdf";

                                var bytess = Convert.FromBase64String(file);
                                using (var imageFile = new FileStream(filepath, FileMode.Create))
                                {
                                    imageFile.Write(bytess, 0, bytess.Length);
                                    imageFile.Flush();
                                }
                                Post.FileUrl = filename;
                                Post.MediaType = "Document";
                                Post.FileData = file;
                                //add Images/Video/Document to Multimedia
                                await _manager.AddMultimediaAsync(Post);
                            }
                        }
                    }

                   
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Post Updated");
        }

        [HttpPost]
        [Route("AddFindsPost")]
        public async Task<IActionResult> AddFinds([FromBody] PostFindsAddModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            PostFindsAddModel Post = new PostFindsAddModel();
            Post.UserId = model.UserId;
            Post.CategoryId = model.CategoryId;
            Post.Subject = model.Subject;
            Post.Message = model.Message;
            Post.Listing_CategoryId = model.Listing_CategoryId;
            Post.Price = model.Price;
            Post.free = ((model.free == 0) ? 0 : 1);

            if (model.CategoryId != 0 && model.CategoryId != null)
            {
                if (model.Subject != null && model.Subject != "string" && model.Subject != "")
                {
                    //add data to Post
                    await _manager.AddFindsPostAsync(Post);
                }
                else
                {
                    return BadRequest("Subject Required");
                }
            }
            else
            {
                return BadRequest("category required");
            }

            //get data from post
            var data = await _manager.PostDetail(Post.UserId);

            PostFindsAddModel Post1 = new PostFindsAddModel();
            Post1.Id = data.Id;
            Post1.UserId = data.User_id;
            Post1.image = model.image;
            Post1.CategoryId = data.Category_id;
            Post1.FileUrl = model.FileUrl;

            try
            {
                string extensions;
                string extension;
               
                if (Post1.image != null)
                {
                    foreach (var file in Post1.image)
                    {
                        if (file != null && file != "string" && file != "")
                        {
                            var data1 = file.Substring(0, 5);
                            switch (data1.ToUpper())
                            {
                                case "IVBOR":
                                    extension = ".jpg";
                                    Post1.MediaType = "image";
                                    extensions = "jpg";
                                    break;

                                case "/9J/4":
                                    extension = ".png";
                                    Post1.MediaType = "image";
                                    extensions = "png";
                                    break;

                                case "AAAAI":
                                    extension = ".mp4";
                                    Post1.MediaType = "video";
                                    extensions = "mp4";
                                    break;

                                default:
                                    extension = ".jpeg";
                                    Post1.MediaType = "image";
                                    extensions = "jpeg";
                                    break;
                            }

                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                            string filepath = uploadsFolder + "/" + myfilename + extension;

                            string filename = "image/" + myfilename + extension;

                            var bytess = Convert.FromBase64String(file);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                            Post1.FileUrl = filename;
                            Post1.MediaType = "Image";
                            Post1.FileData = file;
                            //add Images/Video to Multimedia
                            await _manager.AddFindsMultimediaAsync(Post1);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("FindsPost Added");
        }


        [HttpPost]
        [Route("EditSafetyPost")]
        public async Task<IActionResult> EditSafety([FromBody] PostSafetyAddModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                //edit data of SafetyPost
                await _manager.EditSafetyPostAsync(model);

                // get post multimedia
                var data = await _manager.getpostmultimedia(model.Id, model.UserId);

                var persons = await _manager.getPersonsbyid(model.Id);
                var vechile = await _manager.getVechilebyid(model.Id);
               
                PostSafetyAddModel Post1 = new PostSafetyAddModel();
                Post1.Id = model.Id;
                Post1.UserId = model.UserId;
                Post1.CategoryId = model.CategoryId;
                Post1.image = model.image;
                Post1.video = model.video;
                Post1.oldImage = model.oldImage;
                Post1.oldVideo = model.oldVideo;
                Post1.FileUrl = model.FileUrl;

                //add Person
                if (model.Person != null)
                {
                    foreach (var r in model.Person)
                    {
                        if (r != null)
                        {
                            AddPersonModel person = new AddPersonModel();

                            person.Pid = model.Id;
                            person.userid = model.UserId;
                            person.Hair = r.Hair;
                            person.Top = r.Top;
                            person.Bottom = r.Bottom;
                            person.Shoes = r.Shoes;
                            person.Age = r.Age;
                            person.Build = r.Build;
                            person.Ethinicity = r.Ethinicity;
                            person.Sex = r.Sex;
                            person.OtherDetails = r.OtherDetails;

                            //add vechile details
                            if (person.Hair != null || person.Top != null || person.Bottom != null || person.Shoes != null || person.Age != null || person.Build != null || person.Ethinicity != null || person.Sex != null || person.Ethinicity != null || person.OtherDetails != null)
                            {
                                await _manager.AddPersonDetailAsync(person);
                            }
                            else
                            {
                                return BadRequest("You must add atleast one attribute");
                            }

                        }
                    }

                }


                
                if (model.Vechile != null)
                {
                    //add Vechile
                    foreach (var S in model.Vechile)
                    {
                        AddVechileModel vech = new AddVechileModel();

                        vech.P_id = model.Id;
                        vech.User_id = model.UserId;
                        vech.Color = S.Color;
                        vech.Make = S.Make;
                        vech.Model = S.Model;
                        vech.Year = S.Year;
                        vech.Type = S.Type;
                        vech.RegNo = S.RegNo;
                        vech.Other_Details = S.Other_Details;

                        if (vech.Color != null || vech.Make != null || vech.Model != null || vech.Year != null || vech.Type != null || vech.RegNo != null || vech.Other_Details != null)
                        {
                            //add vechile details
                            await _manager.AddVechileDetailAsync(vech);
                        }
                        else
                        {
                            return BadRequest("You must add atleast one attribute");
                        }

                    }

                }

                foreach (var s in data)             //deletemultimedia
                {
                    await _manager.Deletemultimedia(s.Id);
                }

                if (Post1.oldImage != null)
                {

                    foreach (var r in Post1.oldImage)
                    {
                        if (r != null && r != "string" && r != "")
                        {
                            Post1.FileUrl = r;
                            Post1.MediaType = "image";
                            await _manager.AddSafetyMultimediaAsync(Post1);
                        }
                    }
                }
                if (Post1.oldVideo != null)
                {
                    foreach (var o in Post1.oldVideo)
                    {
                        if (o != null && o != "string" && o != "")
                        {
                            Post1.FileUrl = o;
                            Post1.MediaType = "video";
                            await _manager.AddSafetyMultimediaAsync(Post1);
                        }
                    }
                }
                

                try
                {
                    string extensions;
                    string extension;
                    if (Post1.image != null)
                    {
                        foreach (var file in Post1.image)
                        {
                            if (file != null && file != "string" && file != "")
                            {
                                var data1 = file.Substring(0, 5);
                                switch (data1.ToUpper())
                                {
                                    case "IVBOR":
                                        extension = ".jpg";
                                        Post1.MediaType = "image";
                                        extensions = "jpg";
                                        break;

                                    case "/9J/4":
                                        extension = ".png";
                                        Post1.MediaType = "image";
                                        extensions = "png";
                                        break;

                                    case "AAAAI":
                                        extension = ".mp4";
                                        Post1.MediaType = "video";
                                        extensions = "mp4";
                                        break;

                                    default:
                                        extension = ".jpeg";
                                        Post1.MediaType = "image";
                                        extensions = "jpeg";
                                        break;
                                }
                                var myfilename = string.Format(@"{0}", Guid.NewGuid());

                                var fileExtension = Path.GetExtension(myfilename);

                                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                                string filepath = uploadsFolder + "/" + myfilename + extension;

                                string filename = "image/" + myfilename + extension;

                                var bytess = Convert.FromBase64String(file);
                                using (var imageFile = new FileStream(filepath, FileMode.Create))
                                {
                                    imageFile.Write(bytess, 0, bytess.Length);
                                    imageFile.Flush();
                                }
                                Post1.FileUrl = filename;
                                Post1.MediaType = "Image";
                                Post1.FileData = file;
                                //add Images/Video to Multimedia
                                await _manager.AddSafetyMultimediaAsync(Post1);
                            }
                        }
                    }

                    if (Post1.video != null)
                    {
                        foreach (var file in Post1.video)
                        {
                            if (file != null && file != "string" && file != "")
                            {
                                var myfilename = string.Format(@"{0}", Guid.NewGuid());

                                var fileExtension = Path.GetExtension(myfilename);

                                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Videos");

                                string filepath = uploadsFolder + "/" + myfilename + ".mp4";

                                string filename = "Videos/" + myfilename + ".mp4";

                                var bytess = Convert.FromBase64String(file);
                                using (var videoFile = new FileStream(filepath, FileMode.Create))
                                {
                                    videoFile.Write(bytess, 0, bytess.Length);
                                    videoFile.Flush();
                                }
                                Post1.FileUrl = filename;
                                Post1.MediaType = "Video";
                                Post1.FileData = file;
                                //add Images/Video to Multimedia
                                await _manager.AddSafetyMultimediaAsync(Post1);

                            }
                        }


                    }

                    
                    foreach (var a in persons)
                    {
                        await _manager.Deleteperson(a.Postid);
                    }
                    foreach (var c in vechile)
                    {
                        await _manager.Deletevechile(c.Postid);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           

            return Ok("Safety Post Edited");
        }

        [HttpPost]
        [Route("AddSafetyPost")]
        public async Task<IActionResult> AddSafety([FromBody] PostSafetyAddModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }


            PostSafetyAddModel Post = new PostSafetyAddModel();
            Post.UserId = model.UserId;
            Post.CategoryId = model.CategoryId;
            Post.Subject = model.Subject;
            Post.Message = model.Message;
            Post.SafetyDescription = model.SafetyDescription;
            Post.SafetyPersonDescription = model.SafetyPersonDescription;

            if (model.CategoryId != 0 && model.CategoryId != null)
            {
                if (model.Subject != null && model.Subject != "string" && model.Subject != "")
                {
                    //add data to Post
                    await _manager.AddSafetyPostAsync(Post);
                }
                else
                {
                    return BadRequest("Subject Required");
                }
            }
            else
            {
                return BadRequest("category required");
            }

            
            //get data from post
            var data = await _manager.PostDetail(Post.UserId);

            PostSafetyAddModel Post1 = new PostSafetyAddModel();
            Post1.Id = data.Id;
            Post1.UserId = data.User_id;
            Post1.CategoryId = data.Category_id;
            Post1.image = model.image;
            Post1.video = model.video;
            Post1.FileUrl = model.FileUrl;
           
            //add Person
            foreach (var r in model.Person)
            {
                if (r != null)
                {
                    AddPersonModel person = new AddPersonModel();

                    person.Pid = data.Id;
                    person.userid = data.User_id;
                    person.Hair = r.Hair;
                    person.Top = r.Top;
                    person.Bottom = r.Bottom;
                    person.Shoes = r.Shoes;
                    person.Age = r.Age;
                    person.Build = r.Build;
                    person.Ethinicity = r.Ethinicity;
                    person.Sex = r.Sex;
                    person.OtherDetails = r.OtherDetails;

                    //add vechile details
                    if (person.Hair != null || person.Top != null || person.Bottom != null || person.Shoes != null || person.Age != null || person.Build != null || person.Ethinicity != null || person.Sex != null || person.Ethinicity != null || person.OtherDetails != null)
                    {
                        await _manager.AddPersonDetailAsync(person);
                    }
                    else
                    {
                        return BadRequest("You must add atleast one attribute");
                    }

                }
            }


            if (model.Vechile != null)
            {
                //add Vechile
                foreach (var S in model.Vechile)
                {
                    if (S != null)
                    {
                        AddVechileModel vech = new AddVechileModel();

                        vech.P_id = data.Id;
                        vech.User_id = data.User_id;
                        vech.Color = S.Color;
                        vech.Make = S.Make;
                        vech.Model = S.Model;
                        vech.Year = S.Year;
                        vech.Type = S.Type;
                        vech.RegNo = S.RegNo;
                        vech.Other_Details = S.Other_Details;

                        if (vech.Color != null || vech.Make != null || vech.Model != null || vech.Year != null || vech.Type != null || vech.RegNo != null || vech.Other_Details != null)
                        {
                            //add vechile details
                            await _manager.AddVechileDetailAsync(vech);
                        }
                        else
                        {
                            return BadRequest("You must add atleast one attribute");

                        }

                    }
                }

            }

            try
            {
                string extensions;
                string extension;
                if (Post1.image != null)
                {
                    foreach (var file in Post1.image)
                    {
                        if (file != null && file != "string" && file != "")
                        {
                            var data1 = file.Substring(0, 5);
                            switch (data1.ToUpper())
                            {
                                case "IVBOR":
                                    extension = ".jpg";
                                    Post1.MediaType = "image";
                                    extensions = "jpg";
                                    break;

                                case "/9J/4":
                                    extension = ".png";
                                    Post1.MediaType = "image";
                                    extensions = "png";
                                    break;

                                case "AAAAI":
                                    extension = ".mp4";
                                    Post1.MediaType = "video";
                                    extensions = "mp4";
                                    break;

                                default:
                                    extension = ".jpeg";
                                    Post1.MediaType = "image";
                                    extensions = "jpeg";
                                    break;
                            }
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "image");

                            string filepath = uploadsFolder + "/" + myfilename + extension;

                            string filename = "image/" + myfilename + extension;

                            var bytess = Convert.FromBase64String(file);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                            Post1.FileUrl = filename;
                            Post1.MediaType = "Image";
                            Post1.FileData = file;
                            //add Images/Video to Multimedia
                            await _manager.AddSafetyMultimediaAsync(Post1);
                        }
                    }
                }

                if (Post1.video != null)
                {
                    foreach (var file in Post1.video)
                    {
                        if (file != null && file != "string" && file != "")
                        {
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "Videos");

                            string filepath = uploadsFolder + "/" + myfilename + ".mp4";

                            string filename = "Videos/" + myfilename + ".mp4";

                            var bytess = Convert.FromBase64String(file);
                            using (var videoFile = new FileStream(filepath, FileMode.Create))
                            {
                                videoFile.Write(bytess, 0, bytess.Length);
                                videoFile.Flush();
                            }
                            Post1.FileUrl = filename;
                            Post1.MediaType = "Video";
                            Post1.FileData = file;
                            //add Images/Video to Multimedia
                            await _manager.AddSafetyMultimediaAsync(Post1);

                        }
                    }


                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("SafetyPost Added");
        }


        [HttpGet]
        [Route("get-all-By-Category")]
        public async Task<IActionResult> GetAllAsync(int categoryId)
        {
            return Ok(await _manager.GetAllByCategoryAsync(categoryId));
        }

     
        [HttpPost]
        [Route("Change-Category")]
        public async Task<IActionResult> ChangeCategory(int userid,int postid,int categoryid)
        {
            if (categoryid != 2)
            {
                await _manager.ChangeCategoryAsync(userid, postid, categoryid);

                return Ok("category changed");
            }
            else
            {
                return BadRequest("category cant change to Finds category");
            }
        }

        [HttpPost]
        
        [Route("Post-paged-result")]
        public async Task<IActionResult> PagedResult(JqDataTableRequest model)
        {
            return Ok(await _manager.GetPostPagedResultAsync(model));
        }


        [HttpPost]
        [Route("deletePost")]
        public async Task<IActionResult> Delete(int postid)
        {
            await _manager.DeletePostAsync(postid);
            return Ok("PostDeleted");
        }

        [HttpGet]
        [Route("get-by-postId")]
        public async Task<IActionResult> getPostbypostid(int postid)
        {
            return Ok(await _manager.GetPostByPostId(postid));
        }

        [HttpGet]
        [Route("get-by-ListingId")]
        public async Task<IActionResult> getFindsbyListingid(int listingid)
        {
            return Ok(await _manager.GetFindsPostByListingId(listingid));
        }

        [HttpGet]
        [Route("get-Finds-by-UserId-YoursListing")]
        public async Task<IActionResult> getFindsbyUserid(int userid)
        {
            return Ok(await _manager.GetFindsPostByUserId(userid));
        }

        [HttpGet]
        [Route("get-free-finds")]
        public async Task<IActionResult> GetFreeFinds()
        {
            return Ok(await _manager.GetFreeFinds());
        }
    }
}
