using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnittyGritty.Migrations
{
    /// <inheritdoc />
    public partial class RenameSkeinUsageToGramUsage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkeinUsage",
                table: "PatternSizeYarn");

            migrationBuilder.AddColumn<int>(
                name: "GramUsage",
                table: "PatternSizeYarn",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GramUsage",
                table: "PatternSizeYarn");

            migrationBuilder.AddColumn<float>(
                name: "SkeinUsage",
                table: "PatternSizeYarn",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
