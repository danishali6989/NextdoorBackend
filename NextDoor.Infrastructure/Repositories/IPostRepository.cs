using NextDoor.Dtos.Post;
using NextDoor.Entities;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IPostRepository
    {
        Task AddPostAsync(Post entity);
        Task<Post> getpostdetail(int postid);
        void Edit(Post entity);
        Task<PostDetailDto> PostDetail(int user_id);
        Task<PostDetailDto> getpostdetailbyid(int postid);
        Task<List<PostMultimediaDetailDto>> PostmultimediaDetail(int postid, int user_id);
        Task AddMultimediaAsync(Multimedia entity);
        Task EditMultimediaAsync(Multimedia entity);
        Task DeletePostmultimedia(int id);
        Task DeletePerson(int postid);
        Task DeleteVechile(int postid);
        Task deletepostmultimedia(int id);
        Task deletepostcomment(int postid);
        Task deletepostlikes(int postid);
        Task deleteperson(int postid);
        Task deletevechile(int postid);
        Task DeletePost(int postid);
        Task changecategory(int userid,int postid,int categoryid);

        Task AddPersonDetailAsync(Person entity);
        Task AddVechileDetailAsync(VechileSafety entity);
        Task<List<PostDetailDto>> GetAllByCategoryAsync(int categoryId);
        Task<List<PostDetailDto>> getpostbypostid(int postid);
        Task<List<PostDetailDto>> getfindspostbylistingid(int listingid);
        Task<List<PostDetailDto>> getfindspostbyuserid(int userid);
        Task<List<PostDetailDto>> GetAllPostAsync();
        Task<JqDataTableResponse<PostDetailDto>> GetPostPagedResultAsync(JqDataTableRequest model);
        Task<List<PostPersons>> getPeronsbyid(int Id);
        Task<List<PostComment>> getPostsCommentByid(int id);
        Task<List<PostComment>> getPostsCommentBypostid(int postid);
        Task<List<PostLikes>> getPostlikesById(int id);
        Task<List<PostLikes>> getPostlikesBypostId(int postid);
        Task<List<PostVehicle>> getVehiclebyid(int id);
        Task<List<PostMultimedia>> getPostMultimediaByPostid(int id);
        Task<List<PostMultimedia>> getPostMultimediaRecord(int id);
        Constants.ReactionStatus getPostLikesReactionByUserId(int userid,int postid);
    }
}
