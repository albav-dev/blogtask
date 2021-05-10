using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.CategoryData
{
    public class CategoryData
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}
