using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ImageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cover",
                table: "games",
                newName: "ImageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "games",
                newName: "Cover");
        }
    }
}
