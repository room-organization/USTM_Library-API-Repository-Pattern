using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTMLibrary_API.Migrations
{
    public partial class adding_bookurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookUrl",
                table: "Bibliography",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookUrl",
                table: "Bibliography");
        }
    }
}
