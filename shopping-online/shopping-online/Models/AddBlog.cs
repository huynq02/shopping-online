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

        [Required(ErrorMessage = "Mời nhập Title")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Use 10-150 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mời nhập Author")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Use 10-100 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Mời nhập Description")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Use 10-300 characters")]
        public string Descriptions { get; set; }

        //[Required(ErrorMessage = "Mời nhập Create Date")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Mời nhập Create By")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Use 10-100 characters")]
        public string CreateBy { get; set; }

        [Required(ErrorMessage = "Thêm ảnh")]
        public string Image { get; set; }
        public DateTime ModifyDate { get; set; }

        [Required(ErrorMessage = "Mời nhập Modify By")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Use 10-100 characters")]
        public string ModifyBy { get; set; }

        [Required(ErrorMessage = "Mời nhập Detail")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "Mời nhập Back-Link")]
        public string Back_Link { get; set; }
    }
}