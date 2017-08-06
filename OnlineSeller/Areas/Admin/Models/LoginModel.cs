using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSeller.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string username { set; get; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string password { set; get; }

        public bool rememberme { set; get; }
    }
}
