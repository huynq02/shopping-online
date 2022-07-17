using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    //
    public class Add_Product
    {
        [Required(ErrorMessage ="Product Name is not empty")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Use 10-50 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "ImageProduct is not empty")]
        public string ImageProduct { get; set; }

        [Required(ErrorMessage = "ProductPrice is not empty")]
        [RegularExpression("^[0-9.,]{1,100}$", ErrorMessage = "ProductPrice is a number")]
        public double ProductPrice { get; set; }

        [Required(ErrorMessage = "Color is not empty")]
        public int ColorID { get; set; }

        [Required(ErrorMessage = "ProductQuanity is not empty")]
        [RegularExpression("^[0-9.]{1,100}$", ErrorMessage = "ProductQuanity is a number")]
        public int ProductQuanity { get; set; }

        [Required(ErrorMessage = "Category is not empty")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Status is not empty")]
        public int StatusID { get; set; }

        [Required(ErrorMessage = "Description is not empty")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Use 5-100 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ProductCode is not empty")]
        [StringLength(6, MinimumLength = 1, ErrorMessage = "Use 1-6 characters")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "CreateDate is not empty")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Back_Link is not empty")]
        public string Back_Link { get; set; }
        public List<Color> lstColor { get; set; }
        public List<Category> lstCategories { get; set; }
        public List<status_product> lstStatus { get; set; }

    }
}