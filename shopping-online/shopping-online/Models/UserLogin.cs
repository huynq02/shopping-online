using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class UserLogin
    {
        public int account_id { get; set; }
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be between 2 and 50 characters")]
        public string account_username { get; set; }




        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 20 characters")]
        public string account_password { get; set; }
    }
}