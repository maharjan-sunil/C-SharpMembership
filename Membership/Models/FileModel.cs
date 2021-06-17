using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Membership.Models
{
    public class FileModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}