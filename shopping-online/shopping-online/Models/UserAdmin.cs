using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class UserAdmin
    {
        public List<product> lstPro { get; set; }
        public List<Order> lstOder { get; set; }
        public List<Order_Details> lstOde { get; set; }
        public List<Order_status> lstOSta { get; set; }
    }
}