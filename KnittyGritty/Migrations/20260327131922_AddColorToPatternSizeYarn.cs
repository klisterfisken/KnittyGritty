using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnittyGritty.Migrations
{
    /// <inheritdoc />
    public partial class AddColorToPatternSizeYarn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "PatternSizeYarn",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "PatternSizeYarn");
        }
    }
}
