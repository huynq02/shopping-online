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
        [StringLength(maximumLength:150, MinimumLength =10, ErrorMessage ="Length must be between 10 to 150")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mời nhập Author")]
        [StringLength(maximumLength:100, MinimumLength =5, ErrorMessage ="Length must be between 5 to 100")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Mời nhập Description")]
        [StringLength(maximumLength: 300, MinimumLength = 5, ErrorMessage = "Length must be between 5 to 300")]
        public string Descriptions { get; set; }
        [Required(ErrorMessage = "Mời nhập Create Date")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Mời nhập Create By")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Length must be between 5 to 100")]
        public string CreateBy { get; set; }

        [Required(ErrorMessage = "Thêm ảnh")]
        public string Image { get; set; }
        public DateTime ModifyDate { get; set; }

        [Required(ErrorMessage = "Mời nhập Modify By")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Length must be between 5 to 100")]
        public string ModifyBy { get; set; }

        [Required(ErrorMessage = "Mời nhập Detail")]
        public string Detail { get; set; }
        public string Back_Link { get; set; }
    }
}