using Foolproof;
using Membership.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Membership.Models
{
    public class MemberViewNodel
    {
        public MemberViewNodel()
        {
            Pager = new PagerModel();
        }

        public IEnumerable<MemberModel>ListOfModel { get; set; }
        public PagerModel Pager { get; set; }

    }

    public class MemberModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Member Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        //[Range(0, 100, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(10, ErrorMessage = "String too Long")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Gender")]
        public int Gender { get; set; }

        public string GenderLabel { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public string DOBLabel { get; set; }

        public bool IsFileRequired { get; set; }

        [File(".pdf")]
        [Display(Name = "File")]
        [RequiredIfTrue("IsFileRequired", ErrorMessage = "Please upload file")]
        public HttpPostedFileBase PDFFile { get; set; }

        public string FileName { get; set; }

    }
}