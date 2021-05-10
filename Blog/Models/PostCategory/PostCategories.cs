using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.PostCategory
{
    public class PostCategories
    {
        [Key]
        public int postCategoryId { get; set; }
        public int categoryId { get; set; }
        public int postId { get; set; }

        public List<Category> Categories { get; set; }
        public List<Post> Posts { get; set; }
    }
}
