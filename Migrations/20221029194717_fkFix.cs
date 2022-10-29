using Microsoft.EntityFrameworkCore.Migrations;

namespace YazGel.Migrations
{
    public partial class fkFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Teachers_teacherId1",
                table: "Committees");

            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Teachers_teacherId2",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Committees_teacherId1",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Committees_teacherId2",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "teacherId1",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "teacherId2",
                table: "Committees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "teacherId1",
                table: "Committees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "teacherId2",
                table: "Committees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Committees_teacherId1",
                table: "Committees",
                column: "teacherId1");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_teacherId2",
                table: "Committees",
                column: "teacherId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Teachers_teacherId1",
                table: "Committees",
                column: "teacherId1",
                principalTable: "Teachers",
                principalColumn: "teacherId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Teachers_teacherId2",
                table: "Committees",
                column: "teacherId2",
                principalTable: "Teachers",
                principalColumn: "teacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
