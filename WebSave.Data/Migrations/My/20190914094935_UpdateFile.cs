using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSave.Data.Migrations.My
{
    public partial class UpdateFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Files",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Files");
        }
    }
}
