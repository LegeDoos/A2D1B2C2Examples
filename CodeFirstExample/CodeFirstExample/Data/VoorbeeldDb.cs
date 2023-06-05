using CodeFirstExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Data
{
    public class VoorbeeldDb : DbContext
    {
        public DbSet<Voorbeeld> Voorbeelden { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=.;Initial Catalog=VoorbeeldA2D1B2C2;Integrated Security=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specificeer 
            modelBuilder.Entity<Voorbeeld>()
                .Property(v => v.Name)
                .HasMaxLength(30);

            // data seed
            Voorbeeld vb = new Voorbeeld()
            {
                Id = 1,
                Name = "Test"
            };
            modelBuilder.Entity<Voorbeeld>()
                .HasData(vb);
        }
    }
}
