//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shopping_online
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productsize
    {
        public Nullable<int> product_id { get; set; }
        public Nullable<int> size_id { get; set; }
        public int quantity { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
