using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantClientId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_MaintenanceId",
                table: "Units",
                column: "MaintenanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Maintenances_MaintenanceId",
                table: "Units",
                column: "MaintenanceId",
                principalTable: "Maintenances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Maintenances_MaintenanceId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MaintenanceId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MaintenanceId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "TenantClientId",
                table: "Units");
        }
    }
}
