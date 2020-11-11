using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.UM.Infrastructure.EFCore.Migrations
{
    public partial class UpdateDB_Datatypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Permissions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Permissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Roles",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Users",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    IMG = table.Column<byte[]>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IDCardIMG = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Role_Permission",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RoleID = table.Column<long>(nullable: false),
                    PermissionID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Role_Permission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Role_Permission_Tbl_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Tbl_Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Role_Permission_Tbl_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Tbl_Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Users_Roles",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<long>(nullable: false),
                    RoleID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users_Roles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Users_Roles_Tbl_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Tbl_Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Users_Roles_Tbl_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Tbl_Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Role_Permission_PermissionID",
                table: "Tbl_Role_Permission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Role_Permission_RoleID",
                table: "Tbl_Role_Permission",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Users_Roles_RoleID",
                table: "Tbl_Users_Roles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Users_Roles_UserID",
                table: "Tbl_Users_Roles",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Role_Permission");

            migrationBuilder.DropTable(
                name: "Tbl_Users_Roles");

            migrationBuilder.DropTable(
                name: "Tbl_Permissions");

            migrationBuilder.DropTable(
                name: "Tbl_Roles");

            migrationBuilder.DropTable(
                name: "Tbl_Users");
        }
    }
}
