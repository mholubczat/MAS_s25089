using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnicalInsulation.Migrations
{
    /// <inheritdoc />
    public partial class ScopeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mas");

            migrationBuilder.CreateTable(
                name: "CorrosivityCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrosivityCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scope",
                schema: "mas",
                columns: table => new
                {
                    ScopeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxTemperatureOnInsulationJacket = table.Column<int>(type: "int", nullable: false),
                    DesignAirTemperature = table.Column<int>(type: "int", nullable: false),
                    DesignAirVelocity = table.Column<int>(type: "int", nullable: false),
                    EnvironmentalCorrosivityCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scope", x => x.ScopeId);
                    table.ForeignKey(
                        name: "FK_Scope_CorrosivityCategories_EnvironmentalCorrosivityCategoryId",
                        column: x => x.EnvironmentalCorrosivityCategoryId,
                        principalTable: "CorrosivityCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CorrosivityCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C1" },
                    { 2, "C2" },
                    { 3, "C3" },
                    { 4, "C4" },
                    { 5, "C5I" },
                    { 6, "C5M" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scope_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Scope",
                column: "EnvironmentalCorrosivityCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scope",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "CorrosivityCategories");
        }
    }
}
