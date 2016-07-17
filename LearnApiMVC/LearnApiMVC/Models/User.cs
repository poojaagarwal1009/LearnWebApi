using System;
using System.ComponentModel.DataAnnotations;

namespace LearnApiMVC.Models
{
    public class User
    {

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "User name")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        internal bool IsValid(string emailId, string password)
        {
            throw new NotImplementedException();
        }
    }
}
