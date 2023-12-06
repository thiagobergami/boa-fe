using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
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
                //.OldAnnotation("SqlServer:Identity", "1, 1");

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
