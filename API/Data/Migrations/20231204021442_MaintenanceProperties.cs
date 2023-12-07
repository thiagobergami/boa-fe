// <copyright file="20231204021442_MaintenanceProperties.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace API.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class MaintenanceProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitID = table.Column<int>(type: "int", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_PropertyId",
                table: "Units",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PropertyId",
                table: "Clients",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_UnitID",
                table: "Maintenances",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ClientId",
                table: "Properties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UnitId",
                table: "Properties",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Properties_PropertyId",
                table: "Clients",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Properties_PropertyId",
                table: "Units",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Properties_PropertyId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Properties_PropertyId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Units_PropertyId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PropertyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Clients");
        }
    }
}
