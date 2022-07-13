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

        //var soluongsp = db.products.Select(p => p.product_quantity);
        public int Order_Details_id { get; set; }

        [DisplayName("Account id")]
        public int account_id { get; set; }
        [DisplayName("Account name")]
        public string account_name { get; set; }

        [DisplayName("Product")]
        public int product_id { get; set; }
        public decimal Order_Details_price { get; set; }
        public int Order_Details_num { get; set; }
        public double Order_Details_total_number { get; set; }
        public int Order_id { get; set; }


        [DisplayName("Note")]
        [Required(ErrorMessage = "Note is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Note should be between 2 and 50 characters")]
        public string Order_note { get; set; }
        public int Order_status_id { get; set; }


        public double Order_total_money { get; set; }





        [DisplayName("Order Date")]
        [Required(ErrorMessage = "Order Date is Required")]
        [DateRange("01/01/2022", ErrorMessage = "Date of Birth Must be between 01-01-2022 and Current Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Order_Date { get; set; }
        public int shipping_id { get; set; }

        public virtual Order Order { get; set; }
        public virtual product product { get; set; }
        public virtual Account Account { get; set; }
        public virtual Order_status Order_status { get; set; }
        public virtual shipping shipping { get; set; }
    }
}