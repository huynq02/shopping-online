namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("shipping")]
    public partial class shipping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public shipping()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int shipping_id { get; set; }

        [Required]
        [StringLength(50)]
        public string shipping_name { get; set; }

        [Required]
        [StringLength(100)]
        public string shipping_email { get; set; }

        [Required]
        [StringLength(50)]
        public string shipping_phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
