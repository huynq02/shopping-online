namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int account_id { get; set; }

        [Required]
        [StringLength(50)]
        public string account_email { get; set; }

        [Required]
        [StringLength(30)]
        public string account_password { get; set; }

        [Required]
        [StringLength(30)]
        public string account_name { get; set; }

        [Required]
        [StringLength(10)]
        public string account_phone { get; set; }

        [Required]
        [StringLength(100)]
        public string account_address { get; set; }

        public int? account_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
