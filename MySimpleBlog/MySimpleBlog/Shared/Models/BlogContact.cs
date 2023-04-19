using MySimpleBlog.Shared.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleBlog.Shared.Models
{
    public class BlogContact : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(450, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 50)]
        public string Message { get; set; }

        public virtual DateTimeOffset DateCreated { get; set; }
    }
}
