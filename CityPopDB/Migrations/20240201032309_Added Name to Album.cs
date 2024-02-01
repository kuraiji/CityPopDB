using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityPopDB.Migrations
{
    /// <inheritdoc />
    public partial class AddedNametoAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Albums",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Albums");
        }
    }
}
