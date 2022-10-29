using Microsoft.EntityFrameworkCore.Migrations;

namespace YazGel.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    committeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.committeeId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentGender = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    supervisorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supervisorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supervisorSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supervisorNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supervisorPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supervisorGender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.supervisorId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    teacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherGender = table.Column<int>(type: "int", nullable: false),
                    teacherType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.teacherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Supervisors");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
