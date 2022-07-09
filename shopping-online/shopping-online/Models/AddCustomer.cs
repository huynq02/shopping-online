using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class AddCustomer
    {
        [Required(ErrorMessage ="Username is not empty")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Use 5-50 characters")]
        public string Account_username { get; set; }

        [Required(ErrorMessage = "Email is not empty")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        [RegularExpression("^[a-z][a-z0-9_.]{5,32}@[a-z0-9]{2,}(.[a-z0-9]{2,4}){1,2}$", ErrorMessage = "E-mail is not valid or" +
            "Use letters, numbers & preriods or Must be between 5-32 character or Not special character ")]
        public string Account_email { get; set; }

        [Required(ErrorMessage = "Password is not empty")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Use 8-100 characters")]
        public string Account_password { get; set; }

        [Required(ErrorMessage = "FullName is not empty")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Use 5-50 characters")]
        public string Account_name { get; set; }

        [Required(ErrorMessage = "Phone is not empty")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "Use 9-12 characters")]
        [RegularExpression("^(?:[+0]9)?[0-9]{10}$", ErrorMessage = "Phone is not valid and Use numbers and 0 is first character")]
        public string Account_phone { get; set; }

        [Required(ErrorMessage = "Address is not empty")]
        public string Account_address { get; set; }
        public bool Account_gender { get; set; }
        public bool Account_status { get; set; }

        [Required(ErrorMessage = "CreateDate is not empty")]
        public DateTime CreateDate { get; set; }

    }
}