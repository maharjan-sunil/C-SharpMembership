using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Membership.Custom
{
    public class File : ValidationAttribute
    {
        private readonly string _type;
        public File(string extension)
        {
            _type = extension;
        }
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            else
            {
                var fileExtension = System.IO.Path.GetExtension((value as HttpPostedFileBase).FileName);
                return _type.Equals(fileExtension);
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return "Please select csv file";
        }
    }
}