namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            feedbacks = new HashSet<feedback>();
            Order_Details = new HashSet<Order_Details>();
            productsizes = new HashSet<productsize>();
        }

        [Key]
        public int product_id { get; set; }

        public int image_product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string product_name { get; set; }

        public double product_price { get; set; }

        public int? color_id { get; set; }

        public int product_quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string product_image { get; set; }

        public int? category_id { get; set; }

        public int status_product_id { get; set; }

        [StringLength(2000)]
        public string product_description { get; set; }

        [Required]
        [StringLength(10)]
        public string product_code { get; set; }

        public int? product_sale { get; set; }

        public virtual Category Category { get; set; }

        public virtual Color Color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }

        public virtual image_product image_product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }

        public virtual status_product status_product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productsize> productsizes { get; set; }
    }
}
