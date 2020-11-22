using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class updatestringtodatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Tbl_Candidate_Course_Instructor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegistrationDate",
                table: "Tbl_Candidate_Course_Instructor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
