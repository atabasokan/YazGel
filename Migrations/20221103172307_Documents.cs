using Microsoft.EntityFrameworkCore.Migrations;

namespace YazGel.Migrations
{
    public partial class Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Students",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentProgressId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "Students",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Students",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgressName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentProgress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Internship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSK = table.Column<bool>(type: "bit", nullable: false),
                    GSS = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<bool>(type: "bit", nullable: false),
                    Gov = table.Column<bool>(type: "bit", nullable: false),
                    ComName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComBuss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternshipId = table.Column<int>(type: "int", nullable: false),
                    RecourseConfirm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternshipBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternshipScore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Internship_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "Internship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DocumentProgressId",
                table: "Students",
                column: "DocumentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DocumentsId",
                table: "Students",
                column: "DocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_InternshipId",
                table: "Documents",
                column: "InternshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_DocumentProgress_DocumentProgressId",
                table: "Students",
                column: "DocumentProgressId",
                principalTable: "DocumentProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Documents_DocumentsId",
                table: "Students",
                column: "DocumentsId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_DocumentProgress_DocumentProgressId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Documents_DocumentsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "DocumentProgress");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Internship");

            migrationBuilder.DropIndex(
                name: "IX_Students_DocumentProgressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DocumentsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeacherId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DocumentProgressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DocumentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Students");
        }
    }
}
