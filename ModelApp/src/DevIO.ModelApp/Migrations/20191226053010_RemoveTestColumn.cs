using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.ModelApp.Migrations
{
    public partial class RemoveTestColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Students",
                nullable: true);
        }
    }
}
