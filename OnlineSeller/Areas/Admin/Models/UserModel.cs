using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSeller.Areas.Admin.Models
{
    public class UserModel
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Address")]
        public string Email { get; set; }

    }
}
