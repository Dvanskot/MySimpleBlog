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
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Message { get; set; }
        public virtual DateTimeOffset DateCreated { get; set; }
    }
}
