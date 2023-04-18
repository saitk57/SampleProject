using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-LUH3FHA\\SQLEXPRESS; database=SampleProjectDB;integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

            public DbSet<Product> Products { get; set; }

            public DbSet<Category> Categories { get; set; }

            public DbSet<SubCategory> SubCategories { get; set; }

            public DbSet<Admin> Admins { get; set; }

    }
}
