// <copyright file="20231205183726_UpdateProperties3.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace API.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class UpdateProperties3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Id",
               table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Properties",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // .OldAnnotation("SqlServer:Identity", "1, 1");

            /* migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1"); */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Id",
               table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
