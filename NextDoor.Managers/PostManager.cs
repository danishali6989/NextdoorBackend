using Microsoft.AspNetCore.Http;
using NextDoor.Dtos.Post;
using NextDoor.Factories;
using NextDoor.Infrastructure.DataLayer;
using NextDoor.Infrastructure.Managers;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Post;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Managers
{
    public  class PostManager : IPostManager
    {

        private readonly IPostRepository _repository;
        private readonly ICommentRepository _Commentrepository;
        private readonly ILikeRepository _likerepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public PostManager(IHttpContextAccessor contextAccessor, ICommentRepository commentRepository,
          ILikeRepository likerepository,IPostRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _Commentrepository = commentRepository;
            _likerepository = likerepository;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddPostAsync(PostAddModel model)
        {
            await _repository.AddPostAsync(PostFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
       

        public async Task PostEdit(PostEditModel model)
        {
            var item = await _repository.getpostdetail(model.Id);
            PostFactory.CreateEditPost(model,item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task PostFindsEdit(PostFindsEditModel model)
        {
            var item = await _repository.getpostdetail(model.Id);
            PostFactory.CreateFindsEditPost(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditSafetyPostAsync(PostSafetyAddModel model)
        {
            var item = await _repository.getpostdetail(model.Id);
            PostFactory.CreateSafetyEditPost(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddFindsPostAsync(PostFindsAddModel model)
        {
            await _repository.AddPostAsync(PostFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddSafetyPostAsync(PostSafetyAddModel model)
        {
            await _repository.AddPostAsync(PostFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<PostDetailDto> PostDetail(int user_id)
        {
            return await _repository.PostDetail(user_id);
        }
        public async Task<List<PostPersons>> getPersonsbyid(int postid)
        {
            return await _repository.getPeronsbyid(postid);

        }
        public async Task<List<PostVehicle>> getVechilebyid(int postid)
        {
            return await _repository.getVehiclebyid(postid);

        }


        public async Task<List<PostMultimediaDetailDto>> getpostmultimedia(int postid, int user_id)
        {
            return await _repository.PostmultimediaDetail(postid,user_id);
        }

        public async Task AddMultimediaAsync(PostAddModel model)
        {
            await _repository.AddMultimediaAsync(PostFactory.CreateMultimedia(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddMultimediaAsync(PostEditModel model)
        {
            await _repository.EditMultimediaAsync(PostFactory.CreateMultimedia(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddMultimediaAsync(PostFindsEditModel model)
        {
            await _repository.EditMultimediaAsync(PostFactory.CreateMultimedia(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddFindsMultimediaAsync(PostFindsAddModel model)
        {
            await _repository.AddMultimediaAsync(PostFactory.CreateMultimedia(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddSafetyMultimediaAsync(PostSafetyAddModel model)
        {
            await _repository.AddMultimediaAsync(PostFactory.CreateMultimedia(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task AddPersonDetailAsync(AddPersonModel model)
        {
            await _repository.AddPersonDetailAsync(PostFactory.CreatePerson(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddVechileDetailAsync(AddVechileModel model)
        {
            await _repository.AddVechileDetailAsync(PostFactory.CreateVechile(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Deletemultimedia(int id)
        {
            await _repository.DeletePostmultimedia(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Deleteperson(int postid)
        {
            await _repository.DeletePerson(postid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Deletevechile(int postid)
        {
            await _repository.DeleteVechile(postid);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeletePostAsync(int postid)                       //delete post and its multimedia 
        {
            var post = await _repository.getpostdetailbyid(postid);   //get details of post
            if (post.Category_id == 4)
            {
                var person = await _repository.getPeronsbyid(post.Id);   // detail of person
                foreach (var x in person)
                {
                    await _repository.deleteperson(x.Postid);   //delete person
                }
                var vechicles = await _repository.getVehiclebyid(post.Id);     // getdetails of vechile
                foreach (var y in vechicles)
                {
                    await _repository.deletevechile(y.Postid);   //delete vechile
                }
            }
            
            var listmulti = await _repository.getPostMultimediaRecord(postid);   //get list of multimedia records
            foreach (var s in listmulti)
            {
                await _repository.deletepostmultimedia(s.postid);
            }
            
            var listcomment = await _repository.getPostsCommentBypostid(postid); //get list of comment
            foreach (var t in listcomment)
            {
                await _repository.deletepostcomment(t.Post_id);
            }

            var listlikes = await _repository.getPostlikesBypostId(postid); //get list of likes
            foreach (var y in listlikes)
            {
                await _repository.deletepostlikes(y.Post_id);
            }

            await _repository.DeletePost(postid);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ChangeCategoryAsync(int userid,int postid,int categoryid)   // change category of post
        {
            await _repository.changecategory(userid,postid,categoryid);
        }
        public async Task<List<PostDetailDto>> GetAllByCategoryAsync(int categoryId)
        {
           var data =  await _repository.GetAllByCategoryAsync(categoryId);
            foreach(var item in data)
            {
                item.persons = await _repository.getPeronsbyid(item.Id);
                item.vehicles = await _repository.getVehiclebyid(item.Id);
                item.multimedia = await _repository.getPostMultimediaByPostid(item.Id);
            }
                return data;
        }

        public async Task<List<PostDetailDto>> GetPostByPostId(int postid)
        {
            var data = await _repository.getpostbypostid(postid);
            foreach (var item in data)
            {
                item.persons = await _repository.getPeronsbyid(item.Id);
                item.vehicles = await _repository.getVehiclebyid(item.Id);
                item.multimedia = await _repository.getPostMultimediaByPostid(item.Id);
                
                item.postcomments = await _repository.getPostsCommentByid(item.Id);
                item.multimediaCount = item.multimedia.Count;
                item.postlikes = await _repository.getPostlikesById(item.Id);
                //item.Reaction_Id = _repository.getPostLikesReactionByUserId(userid, item.Id);
                foreach (var r in item.postcomments)
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.likes = likes.Count;
                    // r.Reaction_Id =  _likerepository.getreactionId(r.id);
                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            //item1.likes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.Commentlikes = Commentlikes.Count;
                        }
                    }

                }
            }
            return data;
        }

        public async Task<List<PostDetailDto>> GetFindsPostByListingId(int listingid)
        {
            var data = await _repository.getfindspostbylistingid(listingid);
            foreach (var item in data)
            {
               
                item.multimedia = await _repository.getPostMultimediaByPostid(item.Id);
                
            }
            return data;
        }
        public async Task<List<PostDetailDto>> GetFreeFinds()
        {
            return await _repository.GetFreeFinds();
        }
        public async Task<List<PostDetailDto>> GetFindsPostByUserId(int userid)
        {
            var data = await _repository.getfindspostbyuserid(userid);
            foreach (var item in data)
            {

                item.multimedia = await _repository.getPostMultimediaByPostid(item.Id);

            }
            return data;
        }
        public async Task<List<PostDetailDto>> GetAllPostAsync(int userid)
        {
            var data= await _repository.GetAllPostAsync();
            foreach(var item in data)
            {
                item.persons =  await _repository.getPeronsbyid(item.Id);
                item.vehicles =   await _repository.getVehiclebyid(item.Id);
                item.multimedia = await _repository.getPostMultimediaByPostid(item.Id);
                item.postcomments = await _repository.getPostsCommentByid(item.Id);
                item.PostCommentCount = item.postcomments.Count;
                item.postlikes = await _repository.getPostlikesById(item.Id);
                item.multimediaCount = item.multimedia.Count;

                item.Reaction_Id = _repository.getPostLikesReactionByUserId(userid,item.Id);
                foreach (var r in item.postcomments)
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.likes = likes.Count;
                   // r.Reaction_Id =  _likerepository.getreactionId(r.id);
                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            //item1.likes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.Commentlikes = Commentlikes.Count;
                        }
                    }

                }
            }

            return data;// await _repository.GetAllPostAsync();
        }

        public async Task<List<PostDetailDto>> GetAllBookmarkPostAsync(int userid)
        {
            var data = await _repository.GetAllBookmarkPostAsync(userid);
            foreach (var item in data)
            {
                item.persons = await _repository.getPeronsbyid(item.Id);
                item.vehicles = await _repository.getVehiclebyid(item.Id);
                item.multimedia = await _repository.getPostMultimediaByPostid(item.Id);
                item.postcomments = await _repository.getPostsCommentByid(item.Id);

                item.postlikes = await _repository.getPostlikesById(item.Id);
                item.Reaction_Id = _repository.getPostLikesReactionByUserId(userid, item.Id);
                foreach (var r in item.postcomments)
                {
                    var replies = await _Commentrepository.GetAllCommentById(r.id);
                    r.replies = replies;
                    var likes = await _likerepository.GetAllLikesByCommentId(r.id);
                    r.likes = likes.Count;
                    // r.Reaction_Id =  _likerepository.getreactionId(r.id);
                    if (r.replies.Count > 0)
                    {
                        foreach (var item1 in r.replies)
                        {
                            var innerReplies = await _Commentrepository.GetAllCommentById(item1.Id);
                            item1.replies = innerReplies;
                            //item1.likes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            var Commentlikes = await _likerepository.GetAllLikesByCommentId(item1.Id);
                            item1.Commentlikes = Commentlikes.Count;
                        }
                    }

                }
            }

            return data;// await _repository.GetAllPostAsync();
        }
        public async Task<JqDataTableResponse<PostDetailDto>> GetPostPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetPostPagedResultAsync(model);
        }
    }
}
