using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Helpers;
using Blog.Models;
using Blog.Models.Comments;
using Blog.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {

        private AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public void AddPost(Post post)
        {
            _db.Posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return _db.Posts.ToList();
        }

        //public HomeIndexViewModel GetAllPosts(int pageNumber)
        //{
        //    int pageSize = 5;
        //    int skipAmount = pageSize * (pageNumber - 1);
        //    int postsCount = _db.Posts.Count();
        //    int capacity = skipAmount + pageSize;

        //    return new HomeIndexViewModel
        //    {
        //        PageNumber = pageNumber,
        //        NextPage = postsCount > capacity,
        //        Posts = _db.Posts
        //            .Skip(skipAmount) // ben skip 
        //            .Take(pageSize) //merr nje nr te caktuar postesh nga db
        //            .ToList()
        //    };
        //}

        public HomeIndexViewModel GetAllPosts(int pageNumber, string category, string search)
        {
            Func<Post, bool> InCategory = (post) => { return post.Category == null ? false : post.Category.ToLower().Equals(category.ToLower()); };  //perdoret kjo menyre pasi mund te riperdoret perseri me vone

            int pageSize = 5;
            int skipAmount = pageSize * (pageNumber - 1);
            int capacity = skipAmount + pageSize;

            var query = _db.Posts.AsNoTracking().AsQueryable();

            if (!String.IsNullOrEmpty(category))
                query = query.Where(x => InCategory(x));

            //if (!String.IsNullOrEmpty(search))
            //    query = query.Where(x => x.Title.Contains(search)
            //                        || x.Body.Contains(search)
            //                        || x.Description.Contains(search));

            //kod me i optimizuar 
            if (!String.IsNullOrEmpty(search))
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{search}%")
                                    || EF.Functions.Like(x.Body, $"%{search}%")
                                    || EF.Functions.Like(x.Description, $"%{search}%"));

            int postsCount = query.Count();
            int pageCount = (int)Math.Ceiling((double)postsCount / pageSize);

            return new HomeIndexViewModel
            {
                PageNumber = pageNumber,
                PageCount = pageCount,
                NextPage = postsCount > capacity,
                Pages = PageHelper.PageNumbers(pageNumber, pageCount).ToList(),
                Category = category,
                Search = search,
                Posts = query
                    .Skip(skipAmount) // ben skip pas nje nr te caktuar
                    .Take(pageSize) //merr nje nr te caktuar postesh nga db.ToList()
                    .ToList()
            };
        }

        //private IEnumerable<int> PageNumbers(int pageNumber, int pageCount)
        //{
        //    List<int> pages = new List<int>();
        //    //range of 5
        //    //+2 from left border or -2 from right border

        //    //int midPoint = pageNumber < 3 ? 3
        //    //    : pageNumber > pageCount - 2 ? pageCount - 2
        //    //    : pageNumber;

        //    int midPoint = pageNumber;

        //    if(pageCount < 5)
        //    {
        //        for(int i = 1; i<= pageCount; i++)
        //        {
                    
        //        }
        //    }

        //    if (midPoint < 3)
        //    {
        //        midPoint = 3;
        //    }
        //    else if (midPoint > pageCount - 2)
        //    {
        //        midPoint = pageCount - 2;
        //    }

        //    for (int i = midPoint - 2; i <= midPoint + 2; i++)
        //    {
        //        pages.Add(i);
        //    }

        //    if (pages[0] != 1) //kontrollojm nese eshte faqa e pare
        //    {
        //        pages = pages.Prepend(1).ToList();
        //        if (pages[1] - pages[0] > 1)
        //        {
        //            pages.Insert(1, -1);
        //        }
        //    }

        //    if (pages[pages.Count - 1] != pageCount)
        //    {
        //        pages.Insert(pages.Count, pageCount);
        //        if (pages[pages.Count - 1] - pages[pages.Count - 2] > 1)
        //        {
        //            pages.Insert(pages.Count - 1, -1);
        //        }
        //    }

        //    return pages;
        //}

        public Post GetPost(int id)
        {
            return _db.Posts
                .Include(p=>p.MainComments)
                    .ThenInclude(m => m.SubComments)
                .FirstOrDefault(p=>p.Id == id);
        }

        public void RemovePost(int id)
        {
            _db.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            _db.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddSubComment(SubComment comment)
        {
            _db.SubComments.Add(comment);
        }
    }
}
