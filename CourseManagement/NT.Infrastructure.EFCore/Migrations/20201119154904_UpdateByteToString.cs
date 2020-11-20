using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class UpdateByteToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Course_Tbl_Base_Info_CourseLevel",
                table: "Tbl_Course");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentIMG",
                table: "Tbl_Course_Candidate_Instuctor_Details",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "DailyPlan",
                table: "Tbl_Course",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CourseLevel",
                table: "Tbl_Course",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseCatalog",
                table: "Tbl_Course",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Cost",
                table: "Tbl_Course",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Audience",
                table: "Tbl_Course",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Tbl_Companies",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Course_Tbl_Base_Info_CourseLevel",
                table: "Tbl_Course",
                column: "CourseLevel",
                principalTable: "Tbl_Base_Info",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Course_Tbl_Base_Info_CourseLevel",
                table: "Tbl_Course");

            migrationBuilder.AlterColumn<byte>(
                name: "DocumentIMG",
                table: "Tbl_Course_Candidate_Instuctor_Details",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DailyPlan",
                table: "Tbl_Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "CourseLevel",
                table: "Tbl_Course",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte>(
                name: "CourseCatalog",
                table: "Tbl_Course",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "Cost",
                table: "Tbl_Course",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "Audience",
                table: "Tbl_Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Logo",
                table: "Tbl_Companies",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Course_Tbl_Base_Info_CourseLevel",
                table: "Tbl_Course",
                column: "CourseLevel",
                principalTable: "Tbl_Base_Info",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
