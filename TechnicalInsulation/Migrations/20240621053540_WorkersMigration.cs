using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalInsulation.Migrations
{
    /// <inheritdoc />
    public partial class WorkersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Worker",
                schema: "mas",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HiredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.WorkerId);
                });

            migrationBuilder.CreateTable(
                name: "CostEstimator",
                schema: "mas",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostEstimator", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_CostEstimator_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "mas",
                        principalTable: "Worker",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insulator",
                schema: "mas",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insulator", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_Insulator_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "mas",
                        principalTable: "Worker",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                schema: "mas",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EstimatedWorkload = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualWorkload = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => new { x.ProductId, x.WorkerId });
                    table.ForeignKey(
                        name: "FK_Production_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "mas",
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Production_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "mas",
                        principalTable: "Worker",
                        principalColumn: "WorkerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Production_WorkerId",
                schema: "mas",
                table: "Production",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostEstimator",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Insulator",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Production",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Worker",
                schema: "mas");
        }
    }
}
