namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blog")]
    public partial class blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int blog_id { get; set; }

        [Required]
        [StringLength(200)]
        public string blog_title { get; set; }

        [Required]
        [StringLength(100)]
        public string blog_author { get; set; }

        [Required]
        [StringLength(500)]
        public string blog_descriptions { get; set; }

        public DateTime blog_createdate { get; set; }

        [Required]
        [StringLength(100)]
        public string blog_createby { get; set; }

        [Required]
        [StringLength(100)]
        public string blog_images { get; set; }

        public DateTime blog_modifydate { get; set; }

        [Required]
        [StringLength(100)]
        public string blog_modifyby { get; set; }

        [Required]
        [StringLength(2000)]
        public string blog_detail { get; set; }
    }
}
