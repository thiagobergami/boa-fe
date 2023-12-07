// <copyright file="20231204200702_LastMigration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace API.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class LastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Properties_PropertyId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Clients_ClientId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Units_UnitId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Maintenances_MaintenanceId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Properties_PropertyId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MaintenanceId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_PropertyId",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ClientId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PropertyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MaintenanceId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "TenantClientId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CondominiumId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            /*  migrationBuilder.DropColumn(
                 name: "Id",
                 table: "Properties");

             migrationBuilder.AlterColumn<int>(
                 name: "Id",
                 table: "Properties",
                 type: "int",
                 nullable: false,
                 oldClrType: typeof(int),
                 oldType: "int")
                 .OldAnnotation("SqlServer:Identity", "1, 1"); */

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                columns: new[] { "ClientId", "UnitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Clients_ClientId",
                table: "Properties",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Units_UnitId",
                table: "Properties",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Clients_ClientId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Units_UnitId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "TenantClientId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CondominiumId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MaintenanceId",
                table: "Units",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_PropertyId",
                table: "Units",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ClientId",
                table: "Properties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PropertyId",
                table: "Clients",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Properties_PropertyId",
                table: "Clients",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Clients_ClientId",
                table: "Properties",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Units_UnitId",
                table: "Properties",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Maintenances_MaintenanceId",
                table: "Units",
                column: "MaintenanceId",
                principalTable: "Maintenances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Properties_PropertyId",
                table: "Units",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
