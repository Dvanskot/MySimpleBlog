using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleBlog.Shared.Core.Interfaces
{
    public partial interface IBaseEntity
    {
        int Id { get; set; }
        DateTimeOffset DateCreated { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        DateTimeOffset? Deleted { get; set; }
    }
}
