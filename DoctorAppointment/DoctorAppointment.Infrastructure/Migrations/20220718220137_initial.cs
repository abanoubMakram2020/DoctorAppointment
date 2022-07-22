using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DoctorAppointment.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Appointment",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientName = table.Column<string>(type: "character varying(64)", nullable: false),
                    PatientPhoneNumber = table.Column<string>(type: "character varying(16)", nullable: false),
                    Notes = table.Column<string>(type: "character varying(1024)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AppointmentTimeFrom = table.Column<TimeSpan>(type: "time", nullable: false),
                    AppointmentTimeTo = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment",
                schema: "public");
        }
    }
}
