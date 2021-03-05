using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvcolStaff.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    SalaryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<int>(nullable: false),
                    SalaryGradeName = table.Column<string>(nullable: true),
                    StartRange = table.Column<decimal>(nullable: false),
                    EndRange = table.Column<decimal>(nullable: false),
                    ActualSalary = table.Column<decimal>(nullable: false),
                    MoeNumber = table.Column<string>(nullable: false)
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
                    FirstName = table.Column<string>(maxLength: 35, nullable: false),
                    LastName = table.Column<string>(maxLength: 35, nullable: false),
                    TeacherCode = table.Column<string>(maxLength: 3, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true),
                    StaffID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentsID);
                    table.ForeignKey(
                        name: "FK_Departments_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IrdNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EmergencyContact = table.Column<string>(nullable: false),
                    EcRelaitonship = table.Column<string>(nullable: false),
                    CitizenStatus = table.Column<string>(nullable: false),
                    BirthPlace = table.Column<string>(maxLength: 56, nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    BankAccount = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_PersonalInformation_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false),
                    ReviewStars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Rating_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(nullable: true),
                    StaffID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Roles_Staff_StaffID1",
                        column: x => x.StaffID1,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(nullable: true),
                    DepartmentsID = table.Column<int>(nullable: false),
                    TotalCredits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectsID);
                    table.ForeignKey(
                        name: "FK_Subjects_Departments_DepartmentsID",
                        column: x => x.DepartmentsID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<string>(nullable: true),
                    SubjectsID = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    Day = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Sessions_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Subjects_SubjectsID",
                        column: x => x.SubjectsID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    SubjectsID = table.Column<int>(nullable: false),
                    Credits = table.Column<int>(nullable: false),
                    StandardName = table.Column<string>(maxLength: 60, nullable: true),
                    StandardCode = table.Column<string>(nullable: true),
                    StaffID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.SubjectsID);
                    table.ForeignKey(
                        name: "FK_Standards_Subjects_SubjectsID",
                        column: x => x.SubjectsID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StaffID",
                table: "Departments",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StaffID1",
                table: "Roles",
                column: "StaffID1");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SubjectsID",
                table: "Sessions",
                column: "SubjectsID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DepartmentsID",
                table: "Subjects",
                column: "DepartmentsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
