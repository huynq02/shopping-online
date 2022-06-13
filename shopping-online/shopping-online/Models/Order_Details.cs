namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Details
    {
        [Key]
        public int Order_Details_id { get; set; }

        public int? Order_id { get; set; }

        public int? product_id { get; set; }

        public double? Order_Details_price { get; set; }

        public int? Order_Details_num { get; set; }

        public double? Order_Details_total_number { get; set; }

        public virtual Order Order { get; set; }

        public virtual product product { get; set; }
    }
}
