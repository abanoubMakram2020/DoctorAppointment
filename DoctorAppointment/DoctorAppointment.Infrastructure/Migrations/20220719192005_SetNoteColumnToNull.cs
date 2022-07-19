using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAppointment.Infrastructure.Migrations
{
    public partial class SetNoteColumnToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "public",
                table: "Appointment",
                type: "character varying(1024)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1024)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "public",
                table: "Appointment",
                type: "character varying(1024)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldNullable: true);
        }
    }
}
