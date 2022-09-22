using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBestPractices.Models.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Posts",
                newName: "Body");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Posts",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
