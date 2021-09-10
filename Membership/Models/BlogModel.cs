using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Membership.Models
{
    public class BlogModel
    {
        public int Id { get; set; }

        // [Text(Analyzer = "html_stripper", Name = nameof(BlogModel))]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public decimal Rating { get; set; }
    }

    public class BlogViewModel
    {
        public IEnumerable<BlogModel> ListOfModel { get; set; }
        public string Title { get; set; }
        public decimal Rating { get; set; }
    }
}