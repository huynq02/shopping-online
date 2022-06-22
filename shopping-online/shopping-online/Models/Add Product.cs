using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class Add_Product
    {
        public List<Color> lstColor { get; set; }
        public List<Category> lstCategories { get; set; }
        public List<status_product> lstStatus { get; set; }

    }
}