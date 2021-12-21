using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using NextDoor.Dtos.Post;
using Microsoft.EntityFrameworkCore;
using NextDoor.Utilities;

namespace NextDoor.DataLayer.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dataContext;

        public PostRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddPostAsync(Post entity)
        {
            await _dataContext.Post.AddAsync(entity);
        }

        public async Task<PostDetailDto> PostDetail(int user_id)
        {
            return await (from s in _dataContext.Post
                          where s.User_id == user_id   //&& s.Status == Constants.RecordStatus.Active
                          select new PostDetailDto
                          {
                              Id                      = s.Id,
                              User_id                 = s.User_id,
                              Category_id             = s.Category_id,
                              CategoryName            = s.Categories.CategoryName,
                              Listing_CategoryId      = s.ListingCategoryId,
                              SafetyDescription       = s.SafetyDescription,
                              SafetyPersonDescription = s.SafetyPersonDescription,
                              lan                     = s.lan,
                              lat                     = s.lat,
                              Subject                 = s.Subject,
                              Message                 = s.Message,
                              Price                   = s.Price,
                              Status                  = s.Status,
                              


                          })
                          .AsNoTracking().OrderBy(s=>s.Id)
                          .LastOrDefaultAsync();
        }
        public async Task<PostDetailDto> getpostdetailbyid(int postid)
        {
            return await (from s in _dataContext.Post
                          where s.Id == postid   //&& s.Status == Constants.RecordStatus.Active
                          select new PostDetailDto
                          {
                              Id                      = s.Id,
                              User_id                 = s.User_id,
                              Category_id             = s.Category_id,
                              CategoryName            = s.Categories.CategoryName,
                              Listing_CategoryId      = s.ListingCategoryId,
                              SafetyDescription       = s.SafetyDescription,
                              SafetyPersonDescription = s.SafetyPersonDescription,
                              lan                     = s.lan,
                              lat                     = s.lat,
                              Subject                 = s.Subject,
                              Message                 = s.Message,
                              Price                   = s.Price,
                              Status                  = s.Status,



                          })
                          .AsNoTracking().OrderBy(s => s.Id)
                          .LastOrDefaultAsync();
        }
        public async Task<List<PostMultimediaDetailDto>> PostmultimediaDetail(int postid,int user_id)
        {
            return await  (from s in _dataContext.Multimedia
                          where s.PostId == postid && s.UserId == user_id   //&& s.Status == Constants.RecordStatus.Active
                          select new PostMultimediaDetailDto
                          {
                              Id             = s.Id,
                              Postid         = s.PostId,
                              User_id        = s.UserId,
                              Category_id    = s.CategoryiD,
                              Attachment     = s.Atachments,
                              AttachmentType = s.AtachmentType,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task AddMultimediaAsync(Multimedia entity)
        {
            await _dataContext.Multimedia.AddAsync(entity);
        }

        public async Task EditMultimediaAsync(Multimedia entity)
        {
            await _dataContext.Multimedia.AddAsync(entity);
        }
        public async Task DeletePostmultimedia(int id)
        {
            var data = await _dataContext.Multimedia.FindAsync(id);
           
            _dataContext.Multimedia.Remove(data);
        }
       
        public async Task deletepostmultimedia(int postid)
        {
            var data1 = _dataContext.Multimedia.Where(x => x.PostId == postid).FirstOrDefault();

            _dataContext.Multimedia.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task deletepostcomment(int postid)
        {
            var data1 = _dataContext.Comment.Where(x => x.Post_id == postid).FirstOrDefault();

            _dataContext.Comment.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task deletepostlikes(int postid)
        {
            var data1 = _dataContext.Likes.Where(x => x.Post_id == postid).FirstOrDefault();

            _dataContext.Likes.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeletePerson(int postid)
        {
            var data1 = _dataContext.Person.Where(x => x.P_Id == postid).FirstOrDefault();

            _dataContext.Person.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteVechile(int postid)
        {
            var data1 = _dataContext.VechileSafetty.Where(x => x.Post_Id == postid).FirstOrDefault();

            _dataContext.VechileSafetty.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }

        public async Task deleteperson(int postid)
        {
            var data1 = _dataContext.Person.Where(x => x.P_Id == postid).FirstOrDefault();

            _dataContext.Person.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task deletevechile(int postid)
        {
            var data1 = _dataContext.VechileSafetty.Where(x => x.Post_Id == postid).FirstOrDefault();

            _dataContext.VechileSafetty.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeletePost(int postid)
        {
            var data = await _dataContext.Post.FindAsync(postid);
            //if (data.Category_id == 4)
            //{
            //    var person = _dataContext.Person.Where(x => x.P_Id == postid).FirstOrDefault();
            //    _dataContext.Person.Remove(person);
            //    var vechile = _dataContext.VechileSafetty.Where(x => x.Post_Id == postid).FirstOrDefault();
            //    _dataContext.VechileSafetty.Remove(vechile);
            //}
            _dataContext.Post.Remove(data);
            //var data1 = await _dataContext.Multimedia.FindAsync(postid);

            //_dataContext.Multimedia.Remove(data1);

            //var data1 = _dataContext.Multimedia.Where(x => x.PostId == postid).FirstOrDefault();
            ////data.Category_id = categoryid;
            //_dataContext.Multimedia.Remove(data1);
           
        }
        public void Edit(Post entity)
        {
            _dataContext.Post.Update(entity);
        }
        public async Task<Post> getpostdetail(int postid)
        {
            return await _dataContext.Post.FindAsync(postid);
        }
        public async Task AddPersonDetailAsync(Person entity)
        {
            await _dataContext.Person.AddAsync(entity);
        }
        public async Task AddVechileDetailAsync(VechileSafety entity)
        {
            await _dataContext.VechileSafetty.AddAsync(entity);
        }

       

        public async Task<List<PostDetailDto>> GetAllByCategoryAsync(int categoryId)
        {
            return await (from s in _dataContext.Post
                          where s.Category_id == categoryId

                          select new PostDetailDto
                          {
                              Id                      = s.Id,
                              User_id                 = s.User_id,
                              Category_id             = s.Category_id,
                              CategoryName            = s.Categories.CategoryName,
                              Listing_CategoryId      = s.ListingCategoryId,
                              listingcategoryname     = s.ListingCategories.ListingCategoryName,
                              SafetyDescription       = s.SafetyDescription,
                              SafetyPersonDescription = s.SafetyPersonDescription,
                              Subject                 = s.Subject,
                              Message                 = s.Message,
                              lan                     = s.lan,
                              lat                     = s.lat,
                              Price                   = s.Price,
                              Status                  = s.Status,
                              CreatedOn               = s.CreatedOn,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }


        public async Task<List<PostDetailDto>> getpostbypostid(int postid)
        {
            return await (from s in _dataContext.Post
                             

                          where s.Id == postid

                          select new PostDetailDto
                          {
                              Id                      = s.Id,
                              User_id                 = s.User_id,
                              Category_id             = s.Category_id,
                              CategoryName            = s.Categories.CategoryName,
                              SafetyDescription       = s.SafetyDescription,
                              SafetyPersonDescription = s.SafetyPersonDescription,
                              Listing_CategoryId      = s.ListingCategoryId,
                              Subject                 = s.Subject,
                              Message                 = s.Message,
                              lan                     = s.lan,
                              lat                     = s.lat,
                              Price                   = s.Price,
                              Status                  = s.Status,
                              CreatedOn               = s.CreatedOn,


                             
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<PostDetailDto>> getfindspostbylistingid(int listingid)
        {
            return await (from s in _dataContext.Post


                          where s.ListingCategoryId == listingid

                          select new PostDetailDto
                          {
                              Id                      = s.Id,
                              User_id                 = s.User_id,
                              Category_id             = s.Category_id,
                              CategoryName            = s.Categories.CategoryName,
                              Listing_CategoryId      = s.ListingCategoryId,
                              SafetyDescription       = s.SafetyDescription,
                              SafetyPersonDescription = s.SafetyPersonDescription,
                              Subject                 = s.Subject,
                              Message                 = s.Message,
                              lan                     = s.lan,
                              lat                     = s.lat,
                              Price                   = s.Price,
                              Status                  = s.Status,
                              CreatedOn               = s.CreatedOn,



                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<PostDetailDto>> getfindspostbyuserid(int userid)
        {
            return await (from s in _dataContext.Post


                          where s.Category_id == 2 && s.Id ==userid

                          select new PostDetailDto
                          {
                              Id = s.Id,
                              User_id = s.User_id,
                              Category_id = s.Category_id,
                              CategoryName = s.Categories.CategoryName,
                              Listing_CategoryId = s.ListingCategoryId,
                              SafetyDescription = s.SafetyDescription,
                              SafetyPersonDescription = s.SafetyPersonDescription,
                              Subject = s.Subject,
                              Message = s.Message,
                              lan = s.lan,
                              lat = s.lat,
                              Price = s.Price,
                              Status = s.Status,
                              CreatedOn = s.CreatedOn,



                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<PostDetailDto>> GetAllPostAsync()
        {
            return await (from s in _dataContext.Post
/*                          //join s1 in _dataContext.Multimedia on s.Id equals s1.PostId
                          //into sp
                          //from s1 in sp.DefaultIfEmpty()*/

                          //join s2 in _dataContext.VechileSafetty on s.Id equals s2.Post_Id
                          // into sp2
                          //from s2 in sp2.DefaultIfEmpty()
                          
                          //join s3 in _dataContext.Person on s.Id equals s3.P_Id
                          //into sp1
                          //from s3 in sp1.DefaultIfEmpty()
                          
                         

                          select new PostDetailDto
                          { 
                              Id                      = s.Id,
                              User_id                 = s.User_id,
                              Category_id             = s.Category_id,
                              CategoryName            = s.Categories.CategoryName,
                              Listing_CategoryId      = s.ListingCategoryId,
                              SafetyDescription       = s.SafetyDescription,
                              SafetyPersonDescription = s.SafetyPersonDescription,
                              Subject                 = s.Subject,
                              Message                 = s.Message,
                              lan                     = s.lan,
                              lat                     =  s.lat,
                              Price                   = s.Price,
                              Status                  = s.Status,
                              Bookmark                  =s.Bookmark,
                              //Attachment = s1.Atachments,
                              //AttachmentType = s1.AtachmentType,
                              CreatedOn               = s.CreatedOn,
                             
                              
                              //Hair = s3.Hair,
                              //Top = s3.Top,
                              //Bottom = s3.Bottom,
                              //Shoes = s3.Shoes,
                              //Age = s3.Age,
                              //Build = s3.Build,
                              //Ethinicity = s3.Ethinicity,
                              //Sex = s3.Sex,
                              //OtherDetails = s3.OtherDetails,

                              //Color = s2.Color,
                              //Make = s2.Make,
                              //Model = s2.Model,
                              //Year = s2.Year,
                              //Type = s2.Type,
                              //Other_Details = s2.Other_Details,
                              //RegNo = s2.RegNo,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }


        public async Task<List<PostMultimedia>> getPostMultimediaByPostid(int id)
        {

            try
            {
                var data =await (from s in _dataContext.Multimedia
                            where s.PostId == id
                            select new PostMultimedia
                            {
                                Multimedia_Id  = s.Id,
                                postid         = s.PostId,
                                Attachment     = s.Atachments,
                                AttachmentType = s.AtachmentType
                            }
                          ).ToListAsync();
                return data;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PostMultimedia>> getPostMultimediaRecord(int id)
        {

            try
            {
                var data = await (from s in _dataContext.Multimedia
                                  where s.PostId == id
                                  select new PostMultimedia
                                  {
                                      postid         = s.PostId,
                                      Attachment     = s.Atachments,
                                      AttachmentType = s.AtachmentType
                                  }
                          ).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PostPersons>> getPeronsbyid(int Id)
        {
            return await (from s in _dataContext.Person
                          where s.P_Id == Id

                          select new PostPersons
                          {
                                  Postid       = s.P_Id,
                                  Hair         = s.Hair,
                                  Top          = s.Top,
                                  Bottom       = s.Bottom,
                                  Shoes        = s.Shoes,
                                  Age          = s.Age,
                                  Build        = s.Build,
                                  Ethinicity   = s.Ethinicity,
                                  Sex          = s.Sex,
                                  OtherDetails = s.OtherDetails,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task changecategory(int userid, int postid, int categoryid)
        {
            var data = _dataContext.Post.Where(x => x.User_id == userid && x.Id == postid).FirstOrDefault();
            data.Category_id = categoryid;
            _dataContext.Post.Update(data);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<List<PostComment>> getPostsCommentByid(int Id)
        {
            return await (from s in _dataContext.Comment
                          where s.Post_id == Id && s.CommentParent_Id ==0

                          select new PostComment
                          {
                              id               = s.Id,
                              User_id          = s.User_id,
                              Post_id          = s.Post_id,
                              CommentParent_Id = s.CommentParent_Id,
                              CommentText      = s.CommentText,
                              Attachment1      = s.Attachment1,
                              Attachment2      = s.Attachment2,
                              Attachment3      = s.Attachment3,
                              lat              = s.lat,
                              lng              = s.lng,

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<List<PostComment>> getPostsCommentBypostid(int postId)
        {
            return await (from s in _dataContext.Comment
                          where s.Post_id == postId 

                          select new PostComment
                          {
                              id               = s.Id,
                              User_id          = s.User_id,
                              Post_id          = s.Post_id,
                              CommentParent_Id = s.CommentParent_Id,
                              CommentText      = s.CommentText,
                              Attachment1      = s.Attachment1,
                              Attachment2      = s.Attachment2,
                              Attachment3      = s.Attachment3,
                              lat              = s.lat,
                              lng              = s.lng,

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<PostLikes>> getPostlikesById(int Id)
        {
            return await (from s in _dataContext.Likes
                          where s.Post_id == Id && s.Comment_id == 0

                          select new PostLikes
                          {
                              Comment_id  = s.Comment_id,
                              Reaction_Id = s.Reaction_Id,
                              User_id     = s.User_id,
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<PostLikes>> getPostlikesBypostId(int postId)
        {
            return await (from s in _dataContext.Likes
                          where s.Post_id == postId 

                          select new PostLikes
                          {
                              Post_id     = s.Post_id,
                              Comment_id  = s.Comment_id,
                              Reaction_Id = s.Reaction_Id,
                              User_id     = s.User_id,

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public Constants.ReactionStatus getPostLikesReactionByUserId(int userid,int postid)
        {

            var obj = _dataContext.Likes.Where(x => x.User_id == userid && x.Post_id == postid && x.Comment_id == 0).FirstOrDefault();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.Reaction_Id;

            }

        }
        public async Task<List<PostVehicle>> getVehiclebyid(int Id)
        {
            return await (from s in _dataContext.VechileSafetty

                          where s.Post_Id == Id
                          select new PostVehicle
                          {
                              Postid        = s.Post_Id,
                              Color         = s.Color,
                              Make          = s.Make,
                              Model         = s.Model,
                              Year          = s.Year,
                              Type          = s.Type,
                              RegNo         = s.RegNo,
                              Other_Details = s.Other_Details
                          }).ToListAsync();
        }

        //Post Page result
        public async Task<JqDataTableResponse<PostDetailDto>> GetPostPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.Post
                            join s1 in _dataContext.Multimedia on s.Id equals s1.PostId
                            into sp
                            from s1 in sp.DefaultIfEmpty()

                            join s2 in _dataContext.VechileSafetty on s.Id equals s2.Post_Id
                             into sp2
                            from s2 in sp2.DefaultIfEmpty()

                            join s3 in _dataContext.Person on s.Id equals s3.P_Id
                            into sp1
                            from s3 in sp1.DefaultIfEmpty()
                           
                            where s.Status != Constants.RecordStatus.Deleted && (model.filterKey == null || EF.Functions.Like(s.Subject, "%" + model.filterKey + "%")
                            || EF.Functions.Like(s.Message, "%" + model.filterKey + "%")) 
                           
                            select new PostDetailDto
                            {
                                Id                 = s.Id,
                                User_id            = s.User_id,
                                Category_id        = s.Category_id,
                                Listing_CategoryId = s.ListingCategoryId,
                                Subject            = s.Subject,
                                Message            = s.Message,
                                lan                = s.lan,
                                lat                = s.lat,
                                Price              = s.Price,
                                Status             = s.Status,
                                CreatedOn          = s.CreatedOn,


                               /* Hair = s3.Hair,
                                Top = s3.Top,
                                Bottom = s3.Bottom,
                                Shoes = s3.Shoes,
                                Age = s3.Age,
                                Build = s3.Build,
                                Ethinicity = s3.Ethinicity,
                                Sex = s3.Sex,
                                OtherDetails = s3.OtherDetails,

                                Color = s2.Color,
                                Make = s2.Make,
                                Model = s2.Model,
                                Year = s2.Year,
                                Type = s2.Type,
                                Other_Details = s2.Other_Details,
                                RegNo = s2.RegNo,*/
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<PostDetailDto>
            {
                RecordsTotal = await _dataContext.Post.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

    }
}
