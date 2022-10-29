using Microsoft.EntityFrameworkCore.Migrations;

namespace YazGel.Migrations
{
    public partial class fkTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_role",
                table: "Students",
                column: "role");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Roles_role",
                table: "Students",
                column: "role",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Roles_role",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_role",
                table: "Students");
        }
    }
}
