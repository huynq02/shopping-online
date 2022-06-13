namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("slide")]
    public partial class slide
    {
        [Key]
        public int slide_id { get; set; }

        [Required]
        [StringLength(50)]
        public string slide_title { get; set; }

        [Column(TypeName = "date")]
        public DateTime slide_createdate { get; set; }

        [Required]
        [StringLength(50)]
        public string slide_createby { get; set; }

        [Column(TypeName = "date")]
        public DateTime slide_modifydate { get; set; }

        [Required]
        [StringLength(50)]
        public string slide_modifyby { get; set; }

        [Required]
        [StringLength(50)]
        public string slide_images { get; set; }

        [StringLength(200)]
        public string slide_descriptions { get; set; }

        public int slide_status_id { get; set; }
    }
}
