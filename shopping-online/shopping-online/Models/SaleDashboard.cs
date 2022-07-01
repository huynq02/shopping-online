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
        public List<Account> acc_order { get; set; }
       // so khach da mua hang 
       public Order num_acc_order { get; set; }
        // hien ti ra tong so oder
        public  Order Order { get; set; }
        // danh sach san pham duoc order 
        public List<Order_Details> prodetail { get; set; }
        public Order_Details productdetail { get; set; }
        public List<product> products { get; set; }
        // so san pham duoc mua
        public product product { get; set; }
        
    }
}