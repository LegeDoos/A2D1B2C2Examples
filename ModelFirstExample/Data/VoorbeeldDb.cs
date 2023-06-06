using CodeFirstExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Data
{
    public class VoorbeeldDb : DbContext
    {
        public DbSet<Voorbeeld> Voorbeelden { get; set; }
        public DbSet<VoorbeeldCategorie> VoorbeeldCategorieen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=.;Initial Catalog=VoorbeeldA2D1B2C2;Integrated Security=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specificeer 
            modelBuilder.Entity<Voorbeeld>()
                .Property(v => v.Name)
            .HasMaxLength(30);

            modelBuilder.Entity<VoorbeeldCategorie>()
                .HasMany(e => e.Voorbeelds)
                .WithOne(e => e.VoorbeeldCategorie)
                .HasForeignKey(e => e.VoorbeeldCategorieId)
                .HasPrincipalKey(e => e.Id);

            // data seed
            VoorbeeldCategorie catEen = new VoorbeeldCategorie() { Id = 1, Name = "cat1" };
            modelBuilder.Entity<VoorbeeldCategorie>()
                .HasData(catEen);
            VoorbeeldCategorie catTwee = new VoorbeeldCategorie() { Id = 2, Name = "cat2" };
            modelBuilder.Entity<VoorbeeldCategorie>()
                .HasData(catTwee);
            VoorbeeldCategorie catDrie = new VoorbeeldCategorie() { Id = 3, Name = "cat3" };
            modelBuilder.Entity<VoorbeeldCategorie>()
                .HasData(catDrie);

            Voorbeeld vb = new Voorbeeld() { Id = 1, Name = "Test", VoorbeeldCategorieId = catEen.Id };
            modelBuilder.Entity<Voorbeeld>()
                .HasData(vb);
       
            Voorbeeld vb2 = new Voorbeeld() { Id = 2, Name = "Test2", VoorbeeldCategorieId = catEen.Id };
            modelBuilder.Entity<Voorbeeld>()
                .HasData(vb2);
        }
    }
}
