using System;
using System.Collections.Generic;
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

        public string  RoleId { get; set; }
        public List<string> ListOfRoles { get; set; }

    }
}