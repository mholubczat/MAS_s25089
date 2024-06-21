using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnicalInsulation.Migrations
{
    /// <inheritdoc />
    public partial class ElementsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scope_EnvironmentalCorrosivityCategory_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Scope");

            migrationBuilder.CreateTable(
                name: "PipelineType",
                schema: "mas",
                columns: table => new
                {
                    PipelineTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineType", x => x.PipelineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                schema: "mas",
                columns: table => new
                {
                    Drawing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ScopeId = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElementType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FirstDimension = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SecondDimension = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NominalDiameter = table.Column<int>(type: "int", nullable: true),
                    SecondaryDiameter = table.Column<int>(type: "int", nullable: true),
                    Angle = table.Column<int>(type: "int", nullable: true),
                    PipelineTypeId = table.Column<int>(type: "int", nullable: true),
                    VesselDrawing = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    VesselNumber = table.Column<int>(type: "int", nullable: true),
                    Radius = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => new { x.Drawing, x.Number });
                    table.ForeignKey(
                        name: "FK_Element_Element_VesselDrawing_VesselNumber",
                        columns: x => new { x.VesselDrawing, x.VesselNumber },
                        principalSchema: "mas",
                        principalTable: "Element",
                        principalColumns: new[] { "Drawing", "Number" });
                    table.ForeignKey(
                        name: "FK_Element_PipelineType_PipelineTypeId",
                        column: x => x.PipelineTypeId,
                        principalSchema: "mas",
                        principalTable: "PipelineType",
                        principalColumn: "PipelineTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Scope_ScopeId",
                        column: x => x.ScopeId,
                        principalSchema: "mas",
                        principalTable: "Scope",
                        principalColumn: "ScopeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VesselBottom",
                schema: "mas",
                columns: table => new
                {
                    VesselBottomId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VesselDrawing = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    VesselNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselBottom", x => x.VesselBottomId);
                    table.ForeignKey(
                        name: "FK_VesselBottom_Element_VesselDrawing_VesselNumber",
                        columns: x => new { x.VesselDrawing, x.VesselNumber },
                        principalSchema: "mas",
                        principalTable: "Element",
                        principalColumns: new[] { "Drawing", "Number" });
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "PipelineType",
                columns: new[] { "PipelineTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Pipe" },
                    { 2, "Valve" },
                    { 3, "Elbow" },
                    { 4, "Tee" },
                    { 5, "Reduction" },
                    { 6, "Cap" }
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "VesselBottom",
                columns: new[] { "VesselBottomId", "Name", "VesselDrawing", "VesselNumber" },
                values: new object[,]
                {
                    { 1, "Flat", null, null },
                    { 2, "Sphere", null, null },
                    { 3, "Zeppelin", null, null },
                    { 4, "Cone", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Element_Drawing_Number",
                schema: "mas",
                table: "Element",
                columns: new[] { "Drawing", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Element_PipelineTypeId",
                schema: "mas",
                table: "Element",
                column: "PipelineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_ScopeId",
                schema: "mas",
                table: "Element",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_VesselDrawing_VesselNumber",
                schema: "mas",
                table: "Element",
                columns: new[] { "VesselDrawing", "VesselNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_VesselBottom_VesselDrawing_VesselNumber",
                schema: "mas",
                table: "VesselBottom",
                columns: new[] { "VesselDrawing", "VesselNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Scope_EnvironmentalCorrosivityCategory_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Scope",
                column: "EnvironmentalCorrosivityCategoryId",
                principalSchema: "mas",
                principalTable: "EnvironmentalCorrosivityCategory",
                principalColumn: "EnvironmentalCorrosivityCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scope_EnvironmentalCorrosivityCategory_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Scope");

            migrationBuilder.DropTable(
                name: "VesselBottom",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Element",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "PipelineType",
                schema: "mas");

            migrationBuilder.AddForeignKey(
                name: "FK_Scope_EnvironmentalCorrosivityCategory_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Scope",
                column: "EnvironmentalCorrosivityCategoryId",
                principalSchema: "mas",
                principalTable: "EnvironmentalCorrosivityCategory",
                principalColumn: "EnvironmentalCorrosivityCategoryId");
        }
    }
}
