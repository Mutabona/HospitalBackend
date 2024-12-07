using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalBackend.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_delete_constraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Appointments_AppointmentId",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Users_UserId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Users_UserId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Users_UserId",
                table: "Marks");

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Appointments_AppointmentId",
                table: "Analyzes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Users_UserId",
                table: "Examinations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Users_UserId",
                table: "Histories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Users_UserId",
                table: "Marks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Appointments_AppointmentId",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Users_UserId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Users_UserId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Users_UserId",
                table: "Marks");

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Appointments_AppointmentId",
                table: "Analyzes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Users_UserId",
                table: "Examinations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Users_UserId",
                table: "Histories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Users_UserId",
                table: "Marks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
