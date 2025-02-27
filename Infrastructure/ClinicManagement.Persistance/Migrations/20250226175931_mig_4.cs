using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Appointments");
        }
    }
}
