using PagedList;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class CustomerModel
    {
        //New Comment
        public string search { get; set; }
        public Account acc { get; set; }
        public List<Order_Details> lstOrderCus { get; set; }
        public List<product> product { get; set; }
        public IPagedList<Account> account { get; set; }
        public Role role { get; set; }
        public List<Order> lstOrder { get; set; }
        public List<Order_status> lstOrderStatus { get; set; }
    }
}