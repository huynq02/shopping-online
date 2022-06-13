namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("feedback")]
    public partial class feedback
    {
        [Key]
        public int feetback_id { get; set; }

        [StringLength(2000)]
        public string feetback_content { get; set; }

        public double feetback_ratting { get; set; }

        public int? product_id { get; set; }

        public int account_id { get; set; }

        public virtual product product { get; set; }
    }
}
