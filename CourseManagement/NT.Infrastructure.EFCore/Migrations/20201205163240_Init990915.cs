using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    public partial class Init990915 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Base_Info",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TypeID = table.Column<long>(type: "bigint", nullable: true),
                    ParentID = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Base_Info", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Base_Info_Tbl_Base_Info_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Base_Info_TblFK_Tbl_Course_Tbl_Base_Info_CourseLevel_Base_Info_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Instructor",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Instructor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Companies",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPartner = table.Column<bool>(type: "bit", nullable: false),
                    IsClient = table.Column<bool>(type: "bit", nullable: false),
                    BaseInfoID = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Companies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Companies_Tbl_Base_Info_BaseInfoID",
                        column: x => x.BaseInfoID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Course",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Audience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<long>(type: "bigint", nullable: false),
                    CourseCatalog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseLevel = table.Column<long>(type: "bigint", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanonicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Candidate",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false),
                    NID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalityID = table.Column<long>(type: "bigint", nullable: false),
                    CityOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Candidate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Candidate_Tbl_Base_Info_NationalityID",
                        column: x => x.NationalityID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Candidate_Tbl_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Tbl_Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Course_Instructor",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<long>(type: "bigint", nullable: false),
                    InstructorID = table.Column<long>(type: "bigint", nullable: false),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Course_Instructor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Instructor_Tbl_Base_Info_Location",
                        column: x => x.Location,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Instructor_Tbl_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Tbl_Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Instructor_Tbl_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Tbl_Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Candidate_Course_Instructor",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_InstructorID = table.Column<long>(type: "bigint", nullable: false),
                    CandidateID = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Candidate_Course_Instructor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Candidate_Course_Instructor_Tbl_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Tbl_Candidate",
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
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeID = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentIMG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCI_ID = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Course_Candidate_Instuctor_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Candidate_Instuctor_Details_Tbl_Base_Info_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Tbl_Base_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Candidate_Instuctor_Details_Tbl_Candidate_Course_Instructor_CCI_ID",
                        column: x => x.CCI_ID,
                        principalTable: "Tbl_Candidate_Course_Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Base_Info_ParentID",
                table: "Tbl_Base_Info",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Base_Info_TypeID",
                table: "Tbl_Base_Info",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Candidate_CompanyID",
                table: "Tbl_Candidate",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Candidate_NationalityID",
                table: "Tbl_Candidate",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Candidate_Course_Instructor_CandidateID",
                table: "Tbl_Candidate_Course_Instructor",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Candidate_Course_Instructor_Course_InstructorID",
                table: "Tbl_Candidate_Course_Instructor",
                column: "Course_InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Companies_BaseInfoID",
                table: "Tbl_Companies",
                column: "BaseInfoID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Course_Candidate_Instuctor_Details");

            migrationBuilder.DropTable(
                name: "Tbl_Candidate_Course_Instructor");

            migrationBuilder.DropTable(
                name: "Tbl_Candidate");

            migrationBuilder.DropTable(
                name: "Tbl_Course_Instructor");

            migrationBuilder.DropTable(
                name: "Tbl_Companies");

            migrationBuilder.DropTable(
                name: "Tbl_Course");

            migrationBuilder.DropTable(
                name: "Tbl_Instructor");

            migrationBuilder.DropTable(
                name: "Tbl_Base_Info");
        }
    }
}
