using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class HomeIndexViewModel
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public bool NextPage { get; set; }
        public string Category { get; set; }
        public string Search { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<int> Pages { get; internal set; }
    }
}
