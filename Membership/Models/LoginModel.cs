﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Membership.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Login { get; set; }

        public DateTime LogDate { get; set; }
    }
    //public class LoginLogModel
    //{
    //    public string Log { get; set; }
    //}
}