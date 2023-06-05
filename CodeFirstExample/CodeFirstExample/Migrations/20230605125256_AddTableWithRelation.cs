using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstExample.Migrations
{
    /// <inheritdoc />
    public partial class AddTableWithRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoorbeeldCategorieen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoorbeeldCategorieen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoorbeeldVoorbeeldCategorie",
                columns: table => new
                {
                    VoorbeeldCategoriesId = table.Column<int>(type: "int", nullable: false),
                    VoorbeeldsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoorbeeldVoorbeeldCategorie", x => new { x.VoorbeeldCategoriesId, x.VoorbeeldsId });
                    table.ForeignKey(
                        name: "FK_VoorbeeldVoorbeeldCategorie_VoorbeeldCategorieen_VoorbeeldCategoriesId",
                        column: x => x.VoorbeeldCategoriesId,
                        principalTable: "VoorbeeldCategorieen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoorbeeldVoorbeeldCategorie_Voorbeelden_VoorbeeldsId",
                        column: x => x.VoorbeeldsId,
                        principalTable: "Voorbeelden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Voorbeelden",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 5, 14, 52, 55, 971, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.CreateIndex(
                name: "IX_VoorbeeldVoorbeeldCategorie_VoorbeeldsId",
                table: "VoorbeeldVoorbeeldCategorie",
                column: "VoorbeeldsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoorbeeldVoorbeeldCategorie");

            migrationBuilder.DropTable(
                name: "VoorbeeldCategorieen");

            migrationBuilder.UpdateData(
                table: "Voorbeelden",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 6, 5, 14, 33, 50, 552, DateTimeKind.Local).AddTicks(3148));
        }
    }
}
