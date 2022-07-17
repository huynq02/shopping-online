using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class AddSlide
    {
        [Required(ErrorMessage ="Title is not empty")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Use 10-150 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "CreateDate is not empty")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "CreateBy is not empty")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Use 5-50 characters")]
        public string CreateBy { get; set; }

        [Required(ErrorMessage = "ModifyDate is not empty")]
        public DateTime ModifyDate { get; set; }

        [Required(ErrorMessage = "ModifyBy is not empty")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Use 5-70 characters")]
        public string ModifyBy { get; set; }
        [Required(ErrorMessage = "Imageslide is not empty")]
        public string Imageslide { get; set; }

        [Required(ErrorMessage = "Descriptions is not empty")]
        [StringLength(15000, MinimumLength = 5, ErrorMessage = "Use 5-15000 characters")]
        public string Descriptions { get; set; }
        public bool Status_Id { get; set; }
    }
}