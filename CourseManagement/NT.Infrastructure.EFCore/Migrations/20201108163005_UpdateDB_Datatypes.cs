using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class UpdateDB_Datatypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
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
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
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
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Base_Info",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    TypeID = table.Column<long>(nullable: true),
                    ParentID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Base_Info", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Base_Info_Tbl_Base_Info_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Base_Info_Tbl_Base_Info_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    RolesID = table.Column<long>(nullable: true),
                    PermissionID = table.Column<int>(nullable: false),
                    PermissionsID = table.Column<long>(nullable: true)
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
                name: "Tbl_Companies",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true),
                    TypeID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Companies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Companies_Tbl_Base_Info_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Course",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Audience = table.Column<string>(nullable: true),
                    DailyPlan = table.Column<string>(nullable: true),
                    Cost = table.Column<long>(nullable: true),
                    CourseCatalog = table.Column<byte>(nullable: true),
                    CourseLevel = table.Column<long>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Tbl_Base_Info_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Tbl_Base_Info_CourseLevel",
                        column: x => x.CourseLevel,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Gallery",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    TypeID = table.Column<long>(nullable: false),
                    PhotoAddress = table.Column<string>(nullable: false),
                    ParentID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Gallery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Gallery_Tbl_Gallery_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Tbl_Gallery",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Gallery_Tbl_Base_Info_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
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
                    IDCardIMG = table.Column<byte[]>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyID = table.Column<long>(nullable: true),
                    NID = table.Column<string>(nullable: true),
                    DOB = table.Column<string>(nullable: true),
                    NationalityID = table.Column<long>(nullable: true),
                    CityOfBirth = table.Column<string>(nullable: true),
                    EducationLevel = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Tbl_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Tbl_Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Tbl_Base_Info_NationalityID",
                        column: x => x.NationalityID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Course_Instructor",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CourseID = table.Column<long>(nullable: false),
                    InstructorID = table.Column<long>(nullable: false),
                    SDate = table.Column<string>(nullable: false),
                    EDate = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Venue = table.Column<string>(nullable: false),
                    Location = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Course_Instructor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Instructor_Tbl_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Tbl_Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Instructor_Users_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Instructor_Tbl_Base_Info_Location",
                        column: x => x.Location,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<long>(nullable: false),
                    UsersID = table.Column<long>(nullable: true),
                    RoleID = table.Column<long>(nullable: false),
                    RolesID = table.Column<long>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Tbl_Candidate_Course_Instructor",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Course_InstructorID = table.Column<long>(nullable: false),
                    CandidateID = table.Column<long>(nullable: false),
                    RegistrationDate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Candidate_Course_Instructor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Candidate_Course_Instructor_Users_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Candidate_Course_Instructor_Tbl_Course_Instructor_Course_InstructorID",
                        column: x => x.Course_InstructorID,
                        principalTable: "Tbl_Course_Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Course_Candidate_Instuctor_Details",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    TypeID = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    DocumentIMG = table.Column<byte>(nullable: false),
                    CCI_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Course_Candidate_Instuctor_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Candidate_Instuctor_Details_Tbl_Candidate_Course_Instructor_CCI_ID",
                        column: x => x.CCI_ID,
                        principalTable: "Tbl_Candidate_Course_Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Candidate_Instuctor_Details_Tbl_Base_Info_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionsID",
                table: "RolePermission",
                column: "PermissionsID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RolesID",
                table: "RolePermission",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Base_Info_ParentID",
                table: "Tbl_Base_Info",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Base_Info_TypeID",
                table: "Tbl_Base_Info",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Candidate_Course_Instructor_CandidateID",
                table: "Tbl_Candidate_Course_Instructor",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Candidate_Course_Instructor_Course_InstructorID",
                table: "Tbl_Candidate_Course_Instructor",
                column: "Course_InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Companies_TypeID",
                table: "Tbl_Companies",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Course_CategoryID",
                table: "Tbl_Course",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Course_CourseLevel",
                table: "Tbl_Course",
                column: "CourseLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Course_Candidate_Instuctor_Details_CCI_ID",
                table: "Tbl_Course_Candidate_Instuctor_Details",
                column: "CCI_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Course_Candidate_Instuctor_Details_TypeID",
                table: "Tbl_Course_Candidate_Instuctor_Details",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Course_Instructor_CourseID",
                table: "Tbl_Course_Instructor",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Course_Instructor_InstructorID",
                table: "Tbl_Course_Instructor",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Course_Instructor_Location",
                table: "Tbl_Course_Instructor",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Gallery_ParentID",
                table: "Tbl_Gallery",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Gallery_TypeID",
                table: "Tbl_Gallery",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyID",
                table: "Users",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalityID",
                table: "Users",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RolesID",
                table: "UsersRoles",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UsersID",
                table: "UsersRoles",
                column: "UsersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Tbl_Course_Candidate_Instuctor_Details");

            migrationBuilder.DropTable(
                name: "Tbl_Gallery");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Tbl_Candidate_Course_Instructor");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Tbl_Course_Instructor");

            migrationBuilder.DropTable(
                name: "Tbl_Course");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tbl_Companies");

            migrationBuilder.DropTable(
                name: "Tbl_Base_Info");
        }
    }
}
