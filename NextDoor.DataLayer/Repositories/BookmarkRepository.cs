using NextDoor.Entities;
using NextDoor.Infrastructure.Repositories;
using NextDoor.Models.Bookmark;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using NextDoor.Dtos.Bookmark;
using Microsoft.EntityFrameworkCore;

namespace NextDoor.DataLayer.Repositories
{
    public class BookmarkRepository :IBookmarkRepository
    {
        private readonly DataContext _dataContext;

        public BookmarkRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddBookmark(Bookmark entity)
        {
            await _dataContext.Bookmark.AddAsync(entity);
        }

        

        public async Task DeleteBookmark(int id)
        {
            var data1 = _dataContext.Bookmark.Where(x => x.id == id).FirstOrDefault();
            if (data1.Post_id > 0)
            {
                var data2 = _dataContext.Post.Where(x => x.Id == data1.Post_id).FirstOrDefault();
                data2.Bookmark = false;
                _dataContext.Post.Update(data2);
                await _dataContext.SaveChangesAsync();
            }
            else if (data1.Event_id > 0)
            {
                var data2 = _dataContext.Event.Where(x => x.ID == data1.Event_id).FirstOrDefault();
                data2.EventBookmark = false;
                _dataContext.Event.Update(data2);
                await _dataContext.SaveChangesAsync();
            }
            else if (data1.Poll_id > 0)
            {
                var data2 = _dataContext.Poll.Where(x => x.Id == data1.Poll_id).FirstOrDefault();
                data2.PollBookmark = false;
                _dataContext.Poll.Update(data2);
                await _dataContext.SaveChangesAsync();
            }
            _dataContext.Bookmark.Remove(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task AddBookmarkPost(int postid)
        {
            var data1 = _dataContext.Post.Where(x => x.Id == postid).FirstOrDefault();
            data1.Bookmark = true;
            _dataContext.Post.Update(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task AddBookmarkEventt(int eventid)
        {
            var data1 = _dataContext.Event.Where(x => x.ID == eventid).FirstOrDefault();
            data1.EventBookmark = true;
            _dataContext.Event.Update(data1);
            await _dataContext.SaveChangesAsync();
        }
        public async Task AddBookmarkPoll(int pollid)
        {
            var data1 = _dataContext.Poll.Where(x => x.Id == pollid).FirstOrDefault();
            data1.PollBookmark = true;
            _dataContext.Poll.Update(data1);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<BookmarkDetailDto>> GetAllBookmarkAsync()
        {
            return await (from s in _dataContext.Bookmark

                          select new BookmarkDetailDto
                          {
                              Id = s.id,
                              postid = s.Post_id,
                              categoryid = s.Category_id,
                              pollid = s.Poll_id,
                              eventid = s.Event_id,
                              eventcategoryid = s.EventCategory_id,
                              

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

    }
}
