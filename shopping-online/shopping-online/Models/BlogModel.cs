using PagedList;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class BlogModel
    {
        public string search { get; set; }
        public IPagedList<Blog> blog { get; set; }
        public Blog bg { get; set; }
        public Blog relateBlog { get; set; }
        public List<Category> cate { get; set; }
        public List<Color> color { get; set; }
        public List<product> ListProducts { get; set; }
    }
}