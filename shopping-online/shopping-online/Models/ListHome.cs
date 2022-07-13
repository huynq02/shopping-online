using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopping_online.Context;
using PagedList;

namespace shopping_online.Models
{
    public class ListHome
    {
        public IPagedList<product> listProduct { get; set; }
        public List<Category> listCategory { get; set; }
        public List<Color> listColor { get; set; }
        public List<Slide> listSlide { get; set; }
        public List<product> ListSearchProduct { get; set; }
    }
}