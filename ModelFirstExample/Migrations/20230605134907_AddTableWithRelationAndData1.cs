using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModelFirstExample.Migrations
{
    /// <inheritdoc />
    public partial class AddTableWithRelationAndData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoorbeeldCategorieId",
                table: "Voorbeelden",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VoorbeeldCategorieen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoorbeeldCategorieen", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VoorbeeldCategorieen",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "cat1" },
                    { 2, "cat2" },
                    { 3, "cat3" }
                });

            migrationBuilder.UpdateData(
                table: "Voorbeelden",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "VoorbeeldCategorieId" },
                values: new object[] { new DateTime(2023, 6, 5, 15, 49, 7, 735, DateTimeKind.Local).AddTicks(3914), 1 });

            migrationBuilder.InsertData(
                table: "Voorbeelden",
                columns: new[] { "Id", "CreatedOn", "Name", "VoorbeeldCategorieId" },
                values: new object[] { 2, new DateTime(2023, 6, 5, 15, 49, 7, 735, DateTimeKind.Local).AddTicks(3984), "Test2", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Voorbeelden_VoorbeeldCategorieId",
                table: "Voorbeelden",
                column: "VoorbeeldCategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voorbeelden_VoorbeeldCategorieen_VoorbeeldCategorieId",
                table: "Voorbeelden",
                column: "VoorbeeldCategorieId",
                principalTable: "VoorbeeldCategorieen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voorbeelden_VoorbeeldCategorieen_VoorbeeldCategorieId",
                table: "Voorbeelden");

            migrationBuilder.DropTable(
                name: "VoorbeeldCategorieen");

            migrationBuilder.DropIndex(
                name: "IX_Voorbeelden_VoorbeeldCategorieId",
                table: "Voorbeelden");

            migrationBuilder.DeleteData(
                table: "Voorbeelden",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "VoorbeeldCategorieId",
                table: "Voorbeelden");

            migrationBuilder.UpdateData(
                table: "Voorbeelden",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 5, 15, 18, 13, 281, DateTimeKind.Local).AddTicks(5345));
        }
    }
}
