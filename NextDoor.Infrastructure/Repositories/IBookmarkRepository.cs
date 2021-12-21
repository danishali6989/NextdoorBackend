using NextDoor.Dtos.Bookmark;
using NextDoor.Entities;
using NextDoor.Models.Bookmark;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IBookmarkRepository
    {
        Task AddBookmark(Bookmark entity);
        Task DeleteBookmark(int id);
        Task AddBookmarkPost(int postid);
        Task AddBookmarkEventt(int eventid);
        Task AddBookmarkPoll(int pollid);
        Task<List<BookmarkDetailDto>> GetAllBookmarkAsync(); 
    }
}
