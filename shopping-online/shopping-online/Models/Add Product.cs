using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class Add_Product
    {
        public string ProductName { get; set; }
        public string ImageProduct { get; set; }
        public double ProductPrice { get; set; }
        public int ColorID { get; set; }
        public int ProductQuanity { get; set; }
        public int CategoryID { get; set; }
        public int StatusID { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Color> lstColor { get; set; }
        public List<Category> lstCategories { get; set; }
        public List<status_product> lstStatus { get; set; }

    }
}