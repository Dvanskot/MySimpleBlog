using MySimpleBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleBlog.Shared.Core.Interfaces
{
    public partial interface IContactService
    {
        Task<BlogContact> GetAsync(int id);
        Task<IEnumerable<BlogContact>> GetAllAsync();
        Task<BlogContact> PostAsync(BlogContact blogContact);
    }
}
