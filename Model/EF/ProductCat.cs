namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCat")]
    public partial class ProductCat
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public long? ParrentID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? createTime { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(50)]
        public string MetaKeywords { get; set; }

        [StringLength(200)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }

        public bool ShowOnHome { get; set; }
    }
}
