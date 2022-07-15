using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class HomeAdmin
    {
        public double sum { get; set; }
        public Role role { get; set; }
        public Blog blog { get; set; }
        public Account cusCreate { get; set; }
        public product proCreate { get; set; }
        public product product { get; set; }
        public Account customer { get; set; }
        public Slide slideCreate { get; set; }
        public List<Account> lstCustomer { get; set; }
        public List<Blog> lstBlog { get; set; }
        public List<product> lstProduct { get; set; }
        public List<product> lstProOder { get; set; }
        public List<product> lstProOut { get; set; }
        public Slide editSlide { get; set; }
    }
}