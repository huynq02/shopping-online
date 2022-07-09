using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopping_online.Context;
using PagedList;


namespace shopping_online.Models
{
    public class ProductByColor
    {
        public List<product> ListProductByColor { get; set; }
        public List<product> listP { get; set; }
        public List<Category> listC { get; set; }
        public List<Color> listColor { get; set; }
        //public List<Image_product> listI { get; set; }
    }
}