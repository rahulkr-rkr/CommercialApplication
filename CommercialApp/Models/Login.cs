using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter your Email ID")]
        [Display(Name = "Email ID ")]
        public string useremail { get; set; }

        [Required(ErrorMessage = "Enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}