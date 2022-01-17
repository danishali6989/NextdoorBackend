using NextDoor.Dtos.Post;
using NextDoor.Models.Post;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IPostManager
    {
        Task AddPostAsync(PostAddModel model);
        
        Task PostEdit(PostEditModel model);
        Task PostFindsEdit(PostFindsEditModel model);
        Task EditSafetyPostAsync(PostSafetyAddModel model);
        Task<List<PostPersons>> getPersonsbyid(int postId);
        Task<List<PostVehicle>> getVechilebyid(int postId);
        Task<List<PostMultimediaDetailDto>> getpostmultimedia(int postid,int userid);
        Task AddFindsPostAsync(PostFindsAddModel model);
        Task AddSafetyPostAsync(PostSafetyAddModel model);
        Task<PostDetailDto> PostDetail(int user_id);

        // add multimedia for various categories
        Task AddMultimediaAsync(PostAddModel model);
        Task AddMultimediaAsync(PostFindsEditModel model);
        Task AddMultimediaAsync(PostEditModel model);
        Task AddFindsMultimediaAsync(PostFindsAddModel model);
        Task AddSafetyMultimediaAsync(PostSafetyAddModel model);

        // add person and vechile details
        Task AddPersonDetailAsync(AddPersonModel model);
        Task AddVechileDetailAsync(AddVechileModel model);

        //get detail by categoryId
        Task<List<PostDetailDto>> GetAllByCategoryAsync(int categoryId);
        Task<List<PostDetailDto>> GetPostByPostId(int postid);
        Task<List<PostDetailDto>> GetFindsPostByListingId(int listingid);
        Task<List<PostDetailDto>> GetFindsPostByUserId(int userid);
        Task<List<PostDetailDto>> GetFreeFinds();

        //get all post
        Task<List<PostDetailDto>> GetAllPostAsync(int userid);
        Task<List<PostDetailDto>> GetAllBookmarkPostAsync(int userid);
        Task<JqDataTableResponse<PostDetailDto>> GetPostPagedResultAsync(JqDataTableRequest model);
        Task ChangeCategoryAsync(int userid,int postid,int categoryId);
        Task Deletemultimedia(int id);
        Task Deleteperson(int postid);
        Task Deletevechile(int postid);
        Task DeletePostAsync(int postid);
    }
}
