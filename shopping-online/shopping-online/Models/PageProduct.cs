using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopping_online.Context;
using PagedList;


namespace shopping_online.Models
{
    public class PageProduct
    {
        public IPagedList<product> listProduct { get; set; }
        //public List<Image_product> listImage { get; set; }
        public List<Category> listCategory { get; set; }
        public List<Color> listColor { get; set; }
    }
}