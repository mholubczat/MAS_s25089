using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalInsulation.Migrations
{
    /// <inheritdoc />
    public partial class ProductMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "mas",
                table: "Element",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "mas",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Drawing = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Element_Drawing_Number",
                        columns: x => new { x.Drawing, x.Number },
                        principalSchema: "mas",
                        principalTable: "Element",
                        principalColumns: new[] { "Drawing", "Number" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Drawing_Number",
                schema: "mas",
                table: "Product",
                columns: new[] { "Drawing", "Number" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "mas");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "mas",
                table: "Element");
        }
    }
}
