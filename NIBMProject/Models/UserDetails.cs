using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NIBMProject.Models
{
    [Table("UserLogin")]
    public class UserDetails
    {
        [Required]
        public Guid id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsActivated { get; set; }

        [Required]
        public string Email { get; set; }
    }

    public class Login
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }



    }

    public class Register
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "confirm password")]
        [Compare("Password", ErrorMessage = "your conformation password not match with the password")]
        public string MyProperty { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }



    public class ForgotPassword
    {



        [Required]
        public string Email { get; set; }

    }
}