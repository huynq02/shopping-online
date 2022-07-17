using shopping_online.Common;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class OrderSale
    {
        DBContext db = new DBContext();
        public int Order_Details_id;
        public int product_id;
        public int Order_Details_price;
        public int Order_Details_num;
        public int Order_Details_total_number;
        public int Order_id;
        public int Account_id;
        public int Order_note;
        public int status_id;
        public int Total_money;
        public int Order_date;
        public int Ship_id;
    }
}