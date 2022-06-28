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
    using shopping_online.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class shipping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //[MetadataType(typeof(ShipMetadata))]
        public shipping()
        {
            this.Orders = new HashSet<Order>();
        }
        //public class ShipMetadata
        //{
        //    [removeShip("IsShipuse", "shipping",
        //        ErrorMessage = "UserName already in use")]
        //    public string shipId { get; set; }
        //}

        public int shipping_id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [DisplayName("Name")]
        public string shipping_name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [DisplayName("Email")]

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        public string shipping_email { get; set; }
        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone Number is Required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter a valid Phone Number")]
        public string shipping_phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
