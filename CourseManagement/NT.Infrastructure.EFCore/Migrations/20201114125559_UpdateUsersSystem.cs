using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class UpdateUsersSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Candidate_Course_Instructor_Users_CandidateID",
                table: "Tbl_Candidate_Course_Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Course_Instructor_Users_InstructorID",
                table: "Tbl_Course_Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tbl_Companies_CompanyID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tbl_Base_Info_NationalityID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NationalityID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CityOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NationalityID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IDCardIMG",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IMG",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Tbl_Instructor");

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                table: "Tbl_Instructor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducationLevel",
                table: "Tbl_Instructor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Instructor",
                table: "Tbl_Instructor",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Tbl_Candidate",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CompanyID = table.Column<long>(nullable: false),
                    NID = table.Column<string>(nullable: false),
                    DOB = table.Column<string>(nullable: false),
                    NationalityID = table.Column<long>(nullable: false),
                    CityOfBirth = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Candidate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Candidate_Tbl_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Tbl_Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Candidate_Tbl_Base_Info_NationalityID",
                        column: x => x.NationalityID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Candidate_CompanyID",
                table: "Tbl_Candidate",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Candidate_NationalityID",
                table: "Tbl_Candidate",
                column: "NationalityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Candidate_Course_Instructor_Tbl_Candidate_CandidateID",
                table: "Tbl_Candidate_Course_Instructor",
                column: "CandidateID",
                principalTable: "Tbl_Candidate",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Course_Instructor_Tbl_Instructor_InstructorID",
                table: "Tbl_Course_Instructor",
                column: "InstructorID",
                principalTable: "Tbl_Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Candidate_Course_Instructor_Tbl_Candidate_CandidateID",
                table: "Tbl_Candidate_Course_Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Course_Instructor_Tbl_Instructor_InstructorID",
                table: "Tbl_Course_Instructor");

            migrationBuilder.DropTable(
                name: "Tbl_Candidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Instructor",
                table: "Tbl_Instructor");

            migrationBuilder.RenameTable(
                name: "Tbl_Instructor",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EducationLevel",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CityOfBirth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyID",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DOB",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NID",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NationalityID",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "IDCardIMG",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "IMG",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    PermissionsID = table.Column<long>(type: "bigint", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    RolesID = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permissions_PermissionsID",
                        column: x => x.PermissionsID,
                        principalTable: "Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RolesID",
                        column: x => x.RolesID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    RolesID = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    UsersID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RolesID",
                        column: x => x.RolesID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyID",
                table: "Users",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalityID",
                table: "Users",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionsID",
                table: "RolePermission",
                column: "PermissionsID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RolesID",
                table: "RolePermission",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RolesID",
                table: "UsersRoles",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UsersID",
                table: "UsersRoles",
                column: "UsersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Candidate_Course_Instructor_Users_CandidateID",
                table: "Tbl_Candidate_Course_Instructor",
                column: "CandidateID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Course_Instructor_Users_InstructorID",
                table: "Tbl_Course_Instructor",
                column: "InstructorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tbl_Companies_CompanyID",
                table: "Users",
                column: "CompanyID",
                principalTable: "Tbl_Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tbl_Base_Info_NationalityID",
                table: "Users",
                column: "NationalityID",
                principalTable: "Tbl_Base_Info",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
