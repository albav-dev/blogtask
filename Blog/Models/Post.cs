using Blog.Models.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";

        public string Description { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public List<MainComment> MainComments { get; set; }

        //public List<Category> Categories {get; set; }
    }
}
