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
        public string Title { get; set; }
        [Required(ErrorMessage = "Mời nhập Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Mời nhập Description")]
        public string Descriptions { get; set; }
        [Required(ErrorMessage = "Mời nhập Create Date")]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Mời nhập Create By")]
        public string CreateBy { get; set; }
        [Required(ErrorMessage = "Thêm ảnh")]
        public string Image { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        [Required(ErrorMessage = "Mời nhập Detail")]
        public string Detail { get; set; }
        public string Back_Link { get; set; }
    }
}