using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithEFCore.Models;

namespace WorkingWithEFCore.Data
{
    public class NorthwindDb : DbContext
    {
        public DbSet<Category>? Categories{ get; set; } // map to table name!
        public DbSet<Product>? Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
            string connection = $"Filename={path}";
            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // use fluent api to define stuff instead of attributes in model

            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            
            if (Database.ProviderName?.Contains("SQlite") ?? false)
            {
                modelBuilder.Entity<Product>()
                    .Property(product => product.Cost)
                    .HasConversion<double>();
            }
        }
    }
}
