// <copyright file="20231204012907_UnitCondominuim.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace API.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class UnitCondominuim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Condominiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CondominiumId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    TenantStartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantFinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_Condominiums_CondominiumId",
                        column: x => x.CondominiumId,
                        principalTable: "Condominiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_ClientId",
                table: "Units",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_CondominiumId",
                table: "Units",
                column: "CondominiumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Condominiums");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
