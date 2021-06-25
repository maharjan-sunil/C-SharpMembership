﻿using Membership.Custom;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Membership.Models
{
    public class FileModel
    {
        [Required]
        [File(".csv")]
        public HttpPostedFileBase File { get; set; }
    }

    public class BaseEntityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}