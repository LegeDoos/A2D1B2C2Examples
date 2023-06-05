﻿// <auto-generated />
using System;
using CodeFirstExample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirstExample.Migrations
{
    [DbContext(typeof(VoorbeeldDb))]
    partial class VoorbeeldDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFirstExample.Models.Voorbeeld", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("VoorbeeldCategorieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoorbeeldCategorieId");

                    b.ToTable("Voorbeelden");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2023, 6, 5, 15, 49, 7, 735, DateTimeKind.Local).AddTicks(3914),
                            Name = "Test",
                            VoorbeeldCategorieId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2023, 6, 5, 15, 49, 7, 735, DateTimeKind.Local).AddTicks(3984),
                            Name = "Test2",
                            VoorbeeldCategorieId = 1
                        });
                });

            modelBuilder.Entity("CodeFirstExample.Models.VoorbeeldCategorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VoorbeeldCategorieen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "cat1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "cat2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "cat3"
                        });
                });

            modelBuilder.Entity("CodeFirstExample.Models.Voorbeeld", b =>
                {
                    b.HasOne("CodeFirstExample.Models.VoorbeeldCategorie", "VoorbeeldCategorie")
                        .WithMany("Voorbeelds")
                        .HasForeignKey("VoorbeeldCategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VoorbeeldCategorie");
                });

            modelBuilder.Entity("CodeFirstExample.Models.VoorbeeldCategorie", b =>
                {
                    b.Navigation("Voorbeelds");
                });
#pragma warning restore 612, 618
        }
    }
}
