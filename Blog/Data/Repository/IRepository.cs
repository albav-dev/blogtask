using Blog.Models;
using Blog.Models.Comments;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();
        //HomeIndexViewModel GetAllPosts(int pageNumber);
        HomeIndexViewModel GetAllPosts(int pageNumber, string category, string search);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);

        void AddSubComment(SubComment comment);
        //List<Category> GetAllCategories();

        Task<bool> SaveChangesAsync();
    }
}
