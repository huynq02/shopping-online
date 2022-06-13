namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productsize")]
    public partial class productsize
    {
        public int? product_id { get; set; }

        public int? size_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_quantity { get; set; }

        public virtual product product { get; set; }

        public virtual size size { get; set; }
    }
}
