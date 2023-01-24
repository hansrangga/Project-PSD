using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectPSD.Models;

namespace ProjectPSD.Data
{
    public class ProjectPSDContext : DbContext
    {
        public ProjectPSDContext (DbContextOptions<ProjectPSDContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectPSD.Models.Product>? Product { get; set; }

        public DbSet<ProjectPSD.Models.Cart>? Cart { get; set; }
    }
}
