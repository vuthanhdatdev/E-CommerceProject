using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSeller.Models
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter Username")]
        public string username { set; get; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string password { set; get; }
    }
}
