using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class ProductByCategory
    {
        public List<Product> listProductByCate { get; set; }
        public List<Product> listP { get; set; }
        public List<Category> listC { get; set; }
        public List<Color> listColor { get; set; }
        //public List<Image_product> listI { get; set; }
    }
}