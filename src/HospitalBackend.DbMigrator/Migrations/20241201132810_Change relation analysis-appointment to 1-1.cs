using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalBackend.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class Changerelationanalysisappointmentto11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Analyzes_AppointmentId",
                table: "Analyzes");

            migrationBuilder.CreateIndex(
                name: "IX_Analyzes_AppointmentId",
                table: "Analyzes",
                column: "AppointmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Analyzes_AppointmentId",
                table: "Analyzes");

            migrationBuilder.CreateIndex(
                name: "IX_Analyzes_AppointmentId",
                table: "Analyzes",
                column: "AppointmentId");
        }
    }
}
