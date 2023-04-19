using Microsoft.EntityFrameworkCore;
using MySimpleBlog.Shared.Core.Interfaces;
using MySimpleBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleBlog.Shared.Core.Data
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=localhost;Database=MySimpleBlogDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Loading all models that implements IBaseEntity
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(s => s.GetInterfaces().Any(i => i.Equals(typeof(IBaseEntity)) && s.IsClass && s.IsAbstract && s.IsPublic));

            foreach (var type in types)
            {
                //Model Creating
                var onModelCreatingMethod = type.GetMethods().FirstOrDefault(x => x.Name == type.Name);

                if (onModelCreatingMethod != null)
                {
                    onModelCreatingMethod.Invoke(type, new object[] { modelBuilder });
                }

                //BaseEntity Model Creating
                if (type.BaseType == null || type.BaseType != typeof(IBaseEntity))
                {
                    continue;
                }

               

            }
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is IBaseEntity)
                {
                    if(entry.State == EntityState.Added)
                    {
                        entry.Property("DateCreated").CurrentValue = DateTimeOffset.Now;
                    }
                    else if(entry.State == EntityState.Modified)
                    {
                        entry.Property("LastUpdated").CurrentValue = DateTimeOffset.Now;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<BlogContact> BlogContacts { get; set; }
    }
}
