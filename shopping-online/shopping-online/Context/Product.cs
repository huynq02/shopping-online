//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shopping_online.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.Order_Details = new HashSet<Order_Details>();
            this.productsizes = new HashSet<productsize>();
        }
    
        public int product_id { get; set; }
        public string image_product { get; set; }
        public string product_name { get; set; }
        public double product_price { get; set; }
        public Nullable<int> color_id { get; set; }
        public int product_quantity { get; set; }
        public Nullable<int> category_id { get; set; }
        public int status_product_id { get; set; }
        public string product_description { get; set; }
        public string product_code { get; set; }
        public Nullable<System.DateTime> product_create_date { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }
        public virtual status_product status_product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productsize> productsizes { get; set; }
    }
}
