using Microsoft.EntityFrameworkCore.Migrations;

namespace YazGel.Migrations
{
    public partial class fkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Roles_role",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "Supervisors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "Committees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teacherId",
                table: "Committees",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_role",
                table: "Teachers",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_role",
                table: "Supervisors",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_role",
                table: "Committees",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_teacherId",
                table: "Committees",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_teacherId1",
                table: "Committees",
                column: "teacherId1");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_teacherId2",
                table: "Committees",
                column: "teacherId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Roles_role",
                table: "Committees",
                column: "role",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Teachers_teacherId",
                table: "Committees",
                column: "teacherId",
                principalTable: "Teachers",
                principalColumn: "teacherId",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Roles_role",
                table: "Students",
                column: "role",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_Roles_role",
                table: "Supervisors",
                column: "role",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Roles_role",
                table: "Teachers",
                column: "role",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Roles_role",
                table: "Committees");

            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Teachers_teacherId",
                table: "Committees");

            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Teachers_teacherId1",
                table: "Committees");

            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Teachers_teacherId2",
                table: "Committees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Roles_role",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_Roles_role",
                table: "Supervisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Roles_role",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_role",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Supervisors_role",
                table: "Supervisors");

            migrationBuilder.DropIndex(
                name: "IX_Committees_role",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Committees_teacherId",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Committees_teacherId1",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Committees_teacherId2",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "teacherId",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "teacherId1",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "teacherId2",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "teacherName",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "teacherSurname",
                table: "Committees");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Roles_role",
                table: "Students",
                column: "role",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
