namespace shopping_online.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReviewHE151368
    {
        public long id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string comment { get; set; }

        public int? rating { get; set; }

        public long? product_id { get; set; }

        public long? user_id { get; set; }

        public virtual ProductHE151368 ProductHE151368 { get; set; }

        public virtual ProductHE151368 ProductHE1513681 { get; set; }

        public virtual UsersHE151368 UsersHE151368 { get; set; }

        public virtual UsersHE151368 UsersHE1513681 { get; set; }
    }
}
