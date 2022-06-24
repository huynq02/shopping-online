using PagedList;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class ProductByColor
    {
        public List<product> ListProductByColor { get; set; }
        public List<product> listP { get; set; }
        public List<Category> listC { get; set; }
        public List<Color> listColor { get; set; }
    }
}