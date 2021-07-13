using System;
using System.ComponentModel.DataAnnotations;

namespace Membership.Models
{
    public class MemberModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Gender { get; set; }

        public string GenderLabel { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string DOBLabel { get; set; }

    }
}