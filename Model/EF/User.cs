namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "Please Enter Username", AllowEmptyStrings = false)]
        [Display(Name = "Username: ")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password",AllowEmptyStrings = false)]
        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }


        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public int? ProvinceID { get; set; }

        public int? DistrictID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}

