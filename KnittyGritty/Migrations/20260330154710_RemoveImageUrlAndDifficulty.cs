using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnittyGritty.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageUrlAndDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Pattern");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pattern");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Pattern",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pattern",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
