using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebApp.Data.Migrations
{
    public partial class EmployeeManagerIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Managers_ManagerId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Managers_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Managers_ManagerId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Managers_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
