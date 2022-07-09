using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopping_online.Context;
using PagedList;

namespace shopping_online.Models
{
    public class ProductDetail
    {
        public product objProduct { get; set; }
        //public Image_product objImage { get; set; }
        public List<Category> lstCategory { get; set; }
        public List<Color> lstColor { get; set; }
        public List<product> lstProduct { get; set; }
        public List<size> lstSize { get; set; }
    }
}