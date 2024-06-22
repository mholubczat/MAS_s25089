using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnicalInsulation.Migrations
{
    /// <inheritdoc />
    public partial class MaterialsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_PipelineType_PipelineTypeId",
                schema: "mas",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Scope_EnvironmentalCorrosivityCategory_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Scope");

            migrationBuilder.CreateTable(
                name: "Material",
                schema: "mas",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Thickness = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Density = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerSquareMeter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricePerCubicMeter = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_Product_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "mas",
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "mas",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Wiring",
                schema: "mas",
                columns: table => new
                {
                    WiringId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wiring", x => x.WiringId);
                });

            migrationBuilder.CreateTable(
                name: "Casing",
                schema: "mas",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    EnvironmentalCorrosivityCategoryId = table.Column<int>(type: "int", nullable: false),
                    MaxEnvironmentalCorrosivityCategoryEnvironmentalCorrosivityCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    ProfileId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casing", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Casing_EnvironmentalCorrosivityCategory_EnvironmentalCorrosivityCategoryId",
                        column: x => x.EnvironmentalCorrosivityCategoryId,
                        principalSchema: "mas",
                        principalTable: "EnvironmentalCorrosivityCategory",
                        principalColumn: "EnvironmentalCorrosivityCategoryId");
                    table.ForeignKey(
                        name: "FK_Casing_EnvironmentalCorrosivityCategory_MaxEnvironmentalCorrosivityCategoryEnvironmentalCorrosivityCategoryId",
                        column: x => x.MaxEnvironmentalCorrosivityCategoryEnvironmentalCorrosivityCategoryId,
                        principalSchema: "mas",
                        principalTable: "EnvironmentalCorrosivityCategory",
                        principalColumn: "EnvironmentalCorrosivityCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casing_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "mas",
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casing_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "mas",
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_Casing_Profile_ProfileId1",
                        column: x => x.ProfileId1,
                        principalSchema: "mas",
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insulation",
                schema: "mas",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaxTemperature = table.Column<int>(type: "int", nullable: false),
                    ThermalConductivityCoefficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WiringId = table.Column<int>(type: "int", nullable: true),
                    WiringId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insulation", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Insulation_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "mas",
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insulation_Wiring_WiringId",
                        column: x => x.WiringId,
                        principalSchema: "mas",
                        principalTable: "Wiring",
                        principalColumn: "WiringId");
                    table.ForeignKey(
                        name: "FK_Insulation_Wiring_WiringId1",
                        column: x => x.WiringId1,
                        principalSchema: "mas",
                        principalTable: "Wiring",
                        principalColumn: "WiringId");
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "Profile",
                columns: new[] { "ProfileId", "Name" },
                values: new object[,]
                {
                    { 1, "Flat" },
                    { 2, "Trapezoid" },
                    { 3, "Diagonal" },
                    { 4, "Perforated" }
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "Wiring",
                columns: new[] { "WiringId", "Name" },
                values: new object[,]
                {
                    { 1, "Galvanized" },
                    { 2, "Stainless" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casing_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Casing",
                column: "EnvironmentalCorrosivityCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Casing_MaxEnvironmentalCorrosivityCategoryEnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Casing",
                column: "MaxEnvironmentalCorrosivityCategoryEnvironmentalCorrosivityCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Casing_ProfileId",
                schema: "mas",
                table: "Casing",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Casing_ProfileId1",
                schema: "mas",
                table: "Casing",
                column: "ProfileId1");

            migrationBuilder.CreateIndex(
                name: "IX_Insulation_WiringId",
                schema: "mas",
                table: "Insulation",
                column: "WiringId");

            migrationBuilder.CreateIndex(
                name: "IX_Insulation_WiringId1",
                schema: "mas",
                table: "Insulation",
                column: "WiringId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_PipelineType_PipelineTypeId",
                schema: "mas",
                table: "Element",
                column: "PipelineTypeId",
                principalSchema: "mas",
                principalTable: "PipelineType",
                principalColumn: "PipelineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scope_EnvironmentalCorrosivityCategory_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Scope",
                column: "EnvironmentalCorrosivityCategoryId",
                principalSchema: "mas",
                principalTable: "EnvironmentalCorrosivityCategory",
                principalColumn: "EnvironmentalCorrosivityCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_PipelineType_PipelineTypeId",
                schema: "mas",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Scope_EnvironmentalCorrosivityCategory_EnvironmentalCorrosivityCategoryId",
                schema: "mas",
                table: "Scope");

            migrationBuilder.DropTable(
                name: "Casing",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Insulation",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Material",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Wiring",
                schema: "mas");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_PipelineType_PipelineTypeId",
                schema: "mas",
                table: "Element",
                column: "PipelineTypeId",
                principalSchema: "mas",
                principalTable: "PipelineType",
                principalColumn: "PipelineTypeId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
