using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvcolStaff.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentsID);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    SalaryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<string>(nullable: true),
                    SalaryGradeName = table.Column<string>(nullable: true),
                    StartRange = table.Column<int>(nullable: false),
                    EndRange = table.Column<int>(nullable: false),
                    ActualSalary = table.Column<int>(nullable: false),
                    MoeNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.SalaryID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    TeacherCode = table.Column<string>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    StandardsID = table.Column<string>(nullable: false),
                    CreditsAvaliable = table.Column<int>(nullable: false),
                    StandardName = table.Column<string>(nullable: true),
                    CourseCode = table.Column<string>(nullable: true),
                    StaffID = table.Column<string>(nullable: true),
                    SubjectsID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.StandardsID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(nullable: true),
                    DepartmentsID = table.Column<int>(nullable: false),
                    StandardsID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectsID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
