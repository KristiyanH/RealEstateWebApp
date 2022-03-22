using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebApp.Data.Migrations
{
    public partial class PropertyEmployeeIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Employees_EmployeeId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Employees_EmployeeId",
                table: "Properties",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Employees_EmployeeId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Employees_EmployeeId",
                table: "Properties",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
