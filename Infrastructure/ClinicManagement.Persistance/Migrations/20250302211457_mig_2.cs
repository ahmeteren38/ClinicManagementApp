using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Diseases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Diseases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
