using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class UpdateCandidateForignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Candidate_Tbl_Companies_CompanyID",
                table: "Tbl_Candidate");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyID",
                table: "Tbl_Candidate",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tbl_Base_Info",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Candidate_Tbl_Companies_CompanyID",
                table: "Tbl_Candidate",
                column: "CompanyID",
                principalTable: "Tbl_Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Candidate_Tbl_Companies_CompanyID",
                table: "Tbl_Candidate");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyID",
                table: "Tbl_Candidate",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tbl_Base_Info",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Candidate_Tbl_Companies_CompanyID",
                table: "Tbl_Candidate",
                column: "CompanyID",
                principalTable: "Tbl_Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
