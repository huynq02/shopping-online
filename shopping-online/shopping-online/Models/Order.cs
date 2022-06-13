namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Details = new HashSet<Order_Details>();
        }

        [Key]
        public int Order_id { get; set; }

        public int? account_id { get; set; }

        [StringLength(50)]
        public string Order_note { get; set; }

        public int Order_status_id { get; set; }

        public double Order_total_money { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Order_Date { get; set; }

        public int shipping_id { get; set; }

        public virtual Account Account { get; set; }

        public virtual Order_status Order_status { get; set; }

        public virtual shipping shipping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }
    }
}
