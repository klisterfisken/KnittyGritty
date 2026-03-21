using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnittyGritty.Migrations
{
    /// <inheritdoc />
    public partial class SingleEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "Pattern",
                columns: table => new
                {
                    PatternID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignerID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gauge = table.Column<float>(type: "real", nullable: false),
                    Needles = table.Column<float>(type: "real", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatternType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Craft = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultipleStrands = table.Column<bool>(type: "bit", nullable: false),
                    OverallYarnWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaugePattern = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pattern", x => x.PatternID);
                    table.ForeignKey(
                        name: "FK_Pattern_Designer_DesignerID",
                        column: x => x.DesignerID,
                        principalTable: "Designer",
                        principalColumn: "DesignerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "Yarn",
                columns: table => new
                {
                    YarnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YarnBrandID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YarnWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitWeight = table.Column<int>(type: "int", nullable: false),
                    Meterage = table.Column<int>(type: "int", nullable: false),
                    FiberContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yarn", x => x.YarnID);
                    table.ForeignKey(
                        name: "FK_Yarn_YarnBrand_YarnBrandID",
                        column: x => x.YarnBrandID,
                        principalTable: "YarnBrand",
                        principalColumn: "YarnBrandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatternCategory",
                columns: table => new
                {
                    PatternID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternCategory", x => new { x.PatternID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_PatternCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatternCategory_Pattern_PatternID",
                        column: x => x.PatternID,
                        principalTable: "Pattern",
                        principalColumn: "PatternID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatternLanguage",
                columns: table => new
                {
                    PatternID = table.Column<int>(type: "int", nullable: false),
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternLanguage", x => new { x.PatternID, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_PatternLanguage_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatternLanguage_Pattern_PatternID",
                        column: x => x.PatternID,
                        principalTable: "Pattern",
                        principalColumn: "PatternID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatternSize",
                columns: table => new
                {
                    PatternID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    Circumference = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternSize", x => new { x.PatternID, x.SizeID });
                    table.ForeignKey(
                        name: "FK_PatternSize_Pattern_PatternID",
                        column: x => x.PatternID,
                        principalTable: "Pattern",
                        principalColumn: "PatternID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatternSize_Size_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Size",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatternSizeYarn",
                columns: table => new
                {
                    PatternID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    YarnID = table.Column<int>(type: "int", nullable: false),
                    SkeinUsage = table.Column<float>(type: "real", nullable: false),
                    MeterageUsage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternSizeYarn", x => new { x.PatternID, x.SizeID, x.YarnID });
                    table.ForeignKey(
                        name: "FK_PatternSizeYarn_Pattern_PatternID",
                        column: x => x.PatternID,
                        principalTable: "Pattern",
                        principalColumn: "PatternID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatternSizeYarn_Size_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Size",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatternSizeYarn_Yarn_YarnID",
                        column: x => x.YarnID,
                        principalTable: "Yarn",
                        principalColumn: "YarnID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatternYarn",
                columns: table => new
                {
                    PatternID = table.Column<int>(type: "int", nullable: false),
                    YarnID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternYarn", x => new { x.PatternID, x.YarnID });
                    table.ForeignKey(
                        name: "FK_PatternYarn_Pattern_PatternID",
                        column: x => x.PatternID,
                        principalTable: "Pattern",
                        principalColumn: "PatternID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatternYarn_Yarn_YarnID",
                        column: x => x.YarnID,
                        principalTable: "Yarn",
                        principalColumn: "YarnID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pattern_DesignerID",
                table: "Pattern",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_PatternCategory_CategoryID",
                table: "PatternCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PatternLanguage_LanguageID",
                table: "PatternLanguage",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_PatternSize_SizeID",
                table: "PatternSize",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_PatternSizeYarn_SizeID",
                table: "PatternSizeYarn",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_PatternSizeYarn_YarnID",
                table: "PatternSizeYarn",
                column: "YarnID");

            migrationBuilder.CreateIndex(
                name: "IX_PatternYarn_YarnID",
                table: "PatternYarn",
                column: "YarnID");

            migrationBuilder.CreateIndex(
                name: "IX_Yarn_YarnBrandID",
                table: "Yarn",
                column: "YarnBrandID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatternCategory");

            migrationBuilder.DropTable(
                name: "PatternLanguage");

            migrationBuilder.DropTable(
                name: "PatternSize");

            migrationBuilder.DropTable(
                name: "PatternSizeYarn");

            migrationBuilder.DropTable(
                name: "PatternYarn");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Pattern");

            migrationBuilder.DropTable(
                name: "Yarn");
        }
    }
}
