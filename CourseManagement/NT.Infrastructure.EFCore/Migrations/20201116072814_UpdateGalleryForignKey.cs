using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class UpdateGalleryForignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Gallery_Tbl_Gallery_ParentID",
                table: "Tbl_Gallery");

            migrationBuilder.AlterColumn<long>(
                name: "ParentID",
                table: "Tbl_Gallery",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Gallery_Tbl_Gallery_ParentID",
                table: "Tbl_Gallery",
                column: "ParentID",
                principalTable: "Tbl_Gallery",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Gallery_Tbl_Gallery_ParentID",
                table: "Tbl_Gallery");

            migrationBuilder.AlterColumn<long>(
                name: "ParentID",
                table: "Tbl_Gallery",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Gallery_Tbl_Gallery_ParentID",
                table: "Tbl_Gallery",
                column: "ParentID",
                principalTable: "Tbl_Gallery",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
