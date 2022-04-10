using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebApp.Data.Migrations
{
    public partial class AddedProfilePictoreToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicutre",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicutre",
                table: "AspNetUsers");
        }
    }
}
