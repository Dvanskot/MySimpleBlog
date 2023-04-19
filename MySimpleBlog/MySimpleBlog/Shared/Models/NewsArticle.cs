using MySimpleBlog.Shared.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleBlog.Shared.Models
{
    public class NewsArticle : BaseEntity
    {
        
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual string Content { get; set; }
        public virtual string ImageName { get; set; }
        public virtual DateTimeOffset DateCreated { get; set; }

    }
}
