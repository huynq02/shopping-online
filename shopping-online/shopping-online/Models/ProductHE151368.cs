namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductHE151368
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductHE151368()
        {
            OrdersHE151368 = new HashSet<OrdersHE151368>();
            OrdersHE1513681 = new HashSet<OrdersHE151368>();
            ReviewHE151368 = new HashSet<ReviewHE151368>();
            ReviewHE1513681 = new HashSet<ReviewHE151368>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [StringLength(30)]
        public string color { get; set; }

        [StringLength(10)]
        public string size { get; set; }

        public int? unitInStock { get; set; }

        public double? unitPrice { get; set; }

        [Column(TypeName = "text")]
        public string image { get; set; }

        public long? user_id { get; set; }

        public long? category_id { get; set; }

        public double? rating { get; set; }

        public int? status { get; set; }

        public virtual CategoryHE151368 CategoryHE151368 { get; set; }

        public virtual CategoryHE151368 CategoryHE1513681 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersHE151368> OrdersHE151368 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersHE151368> OrdersHE1513681 { get; set; }

        public virtual UsersHE151368 UsersHE151368 { get; set; }

        public virtual UsersHE151368 UsersHE1513681 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewHE151368> ReviewHE151368 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewHE151368> ReviewHE1513681 { get; set; }
    }
}
