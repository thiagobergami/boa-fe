// <copyright file="20231204192248_UpdateFKUnits2.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace API.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class UpdateFKUnits2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Units");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
