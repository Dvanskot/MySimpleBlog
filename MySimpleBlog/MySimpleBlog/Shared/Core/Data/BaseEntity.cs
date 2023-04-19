using Microsoft.EntityFrameworkCore;
using MySimpleBlog.Shared.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleBlog.Shared.Core.Data
{
    public abstract partial class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTimeOffset DateCreated { get; set; }
        public virtual DateTimeOffset? LastUpdated { get; set; }
        public virtual DateTimeOffset? Deleted { get; set; }

       public static void OnModelCreating<TEntity>(ModelBuilder builder)
            where TEntity : BaseEntity, new()
        {
            builder.Entity<TEntity>().HasKey(e=> e.Id);
        }
    }
}
