using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using shopping_online.Context;

namespace shopping_online.Models
{
    public class ProductModel
    {
        public string search { get; set; }
        public product product { get; set; }
        public IPagedList<product> lstProduct { get; set; }
        public List<Color> color { get; set; }
        public List<status_product> stapro { get; set; }
        public List<Category> lstCategories { get; set; }
    }
}