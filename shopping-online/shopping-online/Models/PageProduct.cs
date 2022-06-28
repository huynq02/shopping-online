using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace shopping_online.Models
{
    public class PageProduct
    {
        public IPagedList<Product> listProduct { get; set; }
        //public List<Image_product> listImage { get; set; }
        public List<Category> listCategory { get; set; }
        public List<Color> listColor { get; set; }
    }
}