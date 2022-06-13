namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartHE151368
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CartHE151368()
        {
            OrdersHE151368 = new HashSet<OrdersHE151368>();
            OrdersHE1513681 = new HashSet<OrdersHE151368>();
        }

        public long id { get; set; }

        public long? user_id { get; set; }

        public double? totalPriceOfProduct { get; set; }

        public bool? checkPay { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [StringLength(30)]
        public string state { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fromOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? toOrder { get; set; }

        public virtual UsersHE151368 UsersHE151368 { get; set; }

        public virtual UsersHE151368 UsersHE1513681 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersHE151368> OrdersHE151368 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersHE151368> OrdersHE1513681 { get; set; }
    }
}
