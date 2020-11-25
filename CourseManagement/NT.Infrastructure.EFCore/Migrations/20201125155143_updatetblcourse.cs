using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class updatetblcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Tbl_Course");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Tbl_Course_Instructor",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Tbl_Course_Instructor");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Tbl_Course",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
