using Microsoft.EntityFrameworkCore.Migrations;

namespace Comicfy.Migrations
{
    public partial class NameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WriterId",
                table: "Writers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PencilerId",
                table: "Pencilers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CoverArtistId",
                table: "CoverArtists",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Writers",
                newName: "WriterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pencilers",
                newName: "PencilerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CoverArtists",
                newName: "CoverArtistId");
        }
    }
}
