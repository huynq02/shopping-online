namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrdersHE151368
    {
        public long id { get; set; }

        public long? product_id { get; set; }

        public long? cart_id { get; set; }

        public int? quantity { get; set; }

        public double? totalPrice { get; set; }

        public int? status { get; set; }

        public virtual CartHE151368 CartHE151368 { get; set; }

        public virtual CartHE151368 CartHE1513681 { get; set; }

        public virtual ProductHE151368 ProductHE151368 { get; set; }

        public virtual ProductHE151368 ProductHE1513681 { get; set; }
    }
}
