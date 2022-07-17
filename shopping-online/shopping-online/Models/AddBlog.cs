using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class AddBlog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is not empty")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Use 10-150 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is not empty")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Use 5-50 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Description is not empty")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Use 10-300 characters")]
        public string Descriptions { get; set; }

        //[Required(ErrorMessage = "Mời nhập Create Date")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Create By is not empty")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Use 5-100 characters")]
        public string CreateBy { get; set; }

        [Required(ErrorMessage = "Image is not empty")]
        public string Image { get; set; }
        public DateTime ModifyDate { get; set; }

        [Required(ErrorMessage = "Modify By is not empty")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Use 10-100 characters")]
        public string ModifyBy { get; set; }

        [Required(ErrorMessage = "Detail is not empty")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "Back-Link is not empty")]
        public string Back_Link { get; set; }
    }
}