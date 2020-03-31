using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalCentreData.Data.Migrations
{
    public partial class ApplicationDbContextData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientsData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Cities = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Appointments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentData_DoctorData_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentData_PatientsData_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicRemarks = table.Column<string>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    SecondDiagnosis = table.Column<string>(nullable: true),
                    ThirdDiagnosis = table.Column<string>(nullable: true),
                    Therapy = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_PatientsData_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentData_DoctorId",
                table: "AppointmentData",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentData_PatientId",
                table: "AppointmentData",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_PatientId",
                table: "Attendance",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentData");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "DoctorData");

            migrationBuilder.DropTable(
                name: "PatientsData");
        }
    }
}
