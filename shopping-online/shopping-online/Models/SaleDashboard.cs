using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class SaleDashboard
    {
        // tinhs tong tien 
       public double sum { get; set; }
        // hien thi danh sach customer order trong thang
        public List<Order> cus_order { get; set; }
        // hien ti ra tong so oder
        public  Order Order { get; set; }
        // danh sach san pham duoc order 
        public List<Order_Details> prodetail { get; set; }
        public List<product> products { get; set; }
        
    }
}