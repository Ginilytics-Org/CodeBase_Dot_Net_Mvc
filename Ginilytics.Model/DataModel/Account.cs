using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ginilytics.Model.DataModel
{
    public class UserRegistrationDto
    {
        //[Required(ErrorMessage = "First Name is required")]
        //[StringLength(50)]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is required")]
        //[StringLength(100)]
        //public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }
    }


    public class UserLoginDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class ForgotPassword
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

    }

    public class LogInStatus
    {
        public bool Status { get; set; } = false;
        public string Messsage { get; set; }
    }

    public class RegisterStatus
    {
        public bool Status { get; set; } = false;
        public string Messsage { get; set; }
    }
}
