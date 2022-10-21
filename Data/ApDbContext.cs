using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using App.Models.Blog;


namespace App.Models
{
    public class ApDbContext : DbContext
    {
        public ApDbContext (DbContextOptions<ApDbContext> options)
            : base(options)
        {
        }

        public DbSet<App.Models.Blog.Category> Category { get; set; }
    }
}
