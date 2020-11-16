using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class Updatetblcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Companies_Tbl_Base_Info_TypeID",
                table: "Tbl_Companies");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Companies_TypeID",
                table: "Tbl_Companies");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Tbl_Companies");

            migrationBuilder.AddColumn<long>(
                name: "BaseInfoID",
                table: "Tbl_Companies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClient",
                table: "Tbl_Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPartner",
                table: "Tbl_Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Companies_BaseInfoID",
                table: "Tbl_Companies",
                column: "BaseInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Companies_Tbl_Base_Info_BaseInfoID",
                table: "Tbl_Companies",
                column: "BaseInfoID",
                principalTable: "Tbl_Base_Info",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Companies_Tbl_Base_Info_BaseInfoID",
                table: "Tbl_Companies");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Companies_BaseInfoID",
                table: "Tbl_Companies");

            migrationBuilder.DropColumn(
                name: "BaseInfoID",
                table: "Tbl_Companies");

            migrationBuilder.DropColumn(
                name: "IsClient",
                table: "Tbl_Companies");

            migrationBuilder.DropColumn(
                name: "IsPartner",
                table: "Tbl_Companies");

            migrationBuilder.AddColumn<long>(
                name: "TypeID",
                table: "Tbl_Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Companies_TypeID",
                table: "Tbl_Companies",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Companies_Tbl_Base_Info_TypeID",
                table: "Tbl_Companies",
                column: "TypeID",
                principalTable: "Tbl_Base_Info",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
