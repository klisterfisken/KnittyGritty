using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnittyGritty.Migrations
{
    /// <inheritdoc />
    public partial class RecreatePatternSizeYarn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE IF EXISTS [PatternSizeYarn]");

            migrationBuilder.CreateTable(
                name: "PatternSizeYarn",
                columns: table => new
                {
                    PatternSizeYarnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternID = table.Column<int>(nullable: false),
                    SizeID = table.Column<int>(nullable: false),
                    YarnID = table.Column<int>(nullable: false),
                    SkeinUsage = table.Column<float>(nullable: false),
                    MeterageUsage = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternSizeYarn", x => x.PatternSizeYarnID);
                    table.ForeignKey("FK_PatternSizeYarn_Pattern", x => x.PatternID, "Pattern", "PatternID", onDelete: ReferentialAction.Cascade);
                    table.ForeignKey("FK_PatternSizeYarn_Size", x => x.SizeID, "Size", "SizeID", onDelete: ReferentialAction.Cascade);
                    table.ForeignKey("FK_PatternSizeYarn_Yarn", x => x.YarnID, "Yarn", "YarnID", onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "PatternSizeYarn");
        }

    }
}
