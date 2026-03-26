using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnittyGritty.Migrations
{
    /// <inheritdoc />
    public partial class RecreatePatternYarn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "PatternYarn");

            migrationBuilder.CreateTable(
                name: "PatternYarn",
                columns: table => new
                {
                    PatternYarnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternID = table.Column<int>(nullable: false),
                    YarnID = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternYarn", x => x.PatternYarnID);
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
                name: "IX_PatternYarn_YarnID",
                table: "PatternYarn",
                column: "YarnID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PatternYarn",
                table: "PatternYarn");

            migrationBuilder.DropIndex(
                name: "IX_PatternYarn_PatternID",
                table: "PatternYarn");

            migrationBuilder.DropColumn(
                name: "PatternYarnID",
                table: "PatternYarn");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "PatternYarn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatternYarn",
                table: "PatternYarn",
                columns: new[] { "PatternID", "YarnID" });
        }
    }
}
