using PagedList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace shopping_online.Models
{
    public class ListHome
    {
        public IPagedList<Product> listProduct { get; set; }
        public List<Category> listCategory { get; set; }
        public List<Color> listColor { get; set; }
    }
}