﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelFirstExample.Migrations
{
    /// <inheritdoc />
    public partial class AddVoorbeeldToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voorbeelden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voorbeelden", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Voorbeelden",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[] { 1, new DateTime(2023, 6, 5, 15, 18, 13, 281, DateTimeKind.Local).AddTicks(5345), "Test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voorbeelden");
        }
    }
}
