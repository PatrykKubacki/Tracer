using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tracer.Models;

namespace Tracer.Data
{
    public class ContentDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Element> Elements { get; set; }

        public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options)
        {
        }
    }
}
