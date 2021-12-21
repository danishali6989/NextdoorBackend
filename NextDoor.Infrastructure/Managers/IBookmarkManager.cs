using NextDoor.Dtos.Bookmark;
using NextDoor.Models.Bookmark;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IBookmarkManager
    {
        Task AddAsync(AddBookmarkModel model);
        Task DeleteAsync(int id);
        Task <List<BookmarkDetailDto>>GetAllAsync();
    }
}
