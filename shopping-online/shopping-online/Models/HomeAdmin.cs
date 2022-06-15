using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class HomeAdmin
    {
        public Role role { get; set; }
        public Blog blog { get; set; }
        public Product product { get; set; }
        public Account customer { get; set; }
        public List<Account> lstCustomer { get; set; }
        public List<Blog> lstBlog { get; set; }
        public List<Product> lstProduct { get; set; }
    }
}