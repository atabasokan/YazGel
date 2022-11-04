using Microsoft.EntityFrameworkCore.Migrations;

namespace YazGel.Migrations
{
    public partial class DocumentsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Internship_InternshipId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Internship_Students_StudentId",
                table: "Internship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Internship",
                table: "Internship");

            migrationBuilder.RenameTable(
                name: "Internship",
                newName: "Internships");

            migrationBuilder.RenameIndex(
                name: "IX_Internship_StudentId",
                table: "Internships",
                newName: "IX_Internships_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Internships",
                table: "Internships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Internships_InternshipId",
                table: "Documents",
                column: "InternshipId",
                principalTable: "Internships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Students_StudentId",
                table: "Internships",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Internships_InternshipId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Students_StudentId",
                table: "Internships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Internships",
                table: "Internships");

            migrationBuilder.RenameTable(
                name: "Internships",
                newName: "Internship");

            migrationBuilder.RenameIndex(
                name: "IX_Internships_StudentId",
                table: "Internship",
                newName: "IX_Internship_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Internship",
                table: "Internship",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Internship_InternshipId",
                table: "Documents",
                column: "InternshipId",
                principalTable: "Internship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Internship_Students_StudentId",
                table: "Internship",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
