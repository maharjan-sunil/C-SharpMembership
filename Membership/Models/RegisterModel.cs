using System.ComponentModel.DataAnnotations;

namespace Membership.Models
{
    public class RegisterModel
    {
        [Required]
        [Display (Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display (Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}