using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Book> Books { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todo: modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
