// <copyright file="20231204192214_UpdateFKUnits.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace API.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class UpdateFKUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Clients_ClientId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Properties_PropertyId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ClientId",
                table: "Units");

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
                name: "PropertyId",
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

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_TenantClientId",
                table: "Units",
                column: "TenantClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Clients_TenantClientId",
                table: "Units",
                column: "TenantClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Properties_PropertyId",
                table: "Units",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Clients_TenantClientId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Properties_PropertyId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_TenantClientId",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "TenantClientId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
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
                name: "ClientId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ClientId",
                table: "Units",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Clients_ClientId",
                table: "Units",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Properties_PropertyId",
                table: "Units",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
