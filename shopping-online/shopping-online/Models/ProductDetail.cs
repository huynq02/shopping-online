using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class ProductDetail
    {
        public Product objProduct { get; set; }
        //public Image_product objImage { get; set; }
        public List<Category> lstCategory { get; set; }
        public List<Color> lstColor { get; set; }
        public List<Product> lstProduct { get; set; }
        public List<Size> lstSize { get; set; }
    }
}