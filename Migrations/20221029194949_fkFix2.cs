using Microsoft.EntityFrameworkCore.Migrations;

namespace YazGel.Migrations
{
    public partial class fkFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teacherName",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "teacherSurname",
                table: "Committees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "teacherName",
                table: "Committees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "teacherSurname",
                table: "Committees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
