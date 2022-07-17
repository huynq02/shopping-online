using PagedList;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class SearchModel
    {
        public string search { get; set; }
        public string result { get; set; }
        public IPagedList<Blog> lstBlog { get; set; }
        public IPagedList<product> lstPro { get; set; }
        public List<product> ListProduct { get; set; }
    }
}