using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.SM.Infrastructure.EFCore.Migrations
{
    public partial class DBSite_990815 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Site_Base",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    MainTitle = table.Column<string>(nullable: true),
                    MainDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_Base", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_EvaluationResult",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Percentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_EvaluationResult", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_FAQ",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_FAQ", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_FunFact",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ValueNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_FunFact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_About",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Site_Base_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_About", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Site_About_Site_Base_Site_Base_Id",
                        column: x => x.Site_Base_Id,
                        principalTable: "Site_Base",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site_CertifiedProgram",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Site_Base_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_CertifiedProgram", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Site_CertifiedProgram_Site_Base_Site_Base_Id",
                        column: x => x.Site_Base_Id,
                        principalTable: "Site_Base",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site_ClientAlliance",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Site_Base_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_ClientAlliance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Site_ClientAlliance_Site_Base_Site_Base_Id",
                        column: x => x.Site_Base_Id,
                        principalTable: "Site_Base",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site_Course",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Site_Base_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Site_Course_Site_Base_Site_Base_Id",
                        column: x => x.Site_Base_Id,
                        principalTable: "Site_Base",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site_Facility",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HasBullet = table.Column<bool>(nullable: false),
                    Img = table.Column<string>(nullable: true),
                    Site_Base_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_Facility", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Site_Facility_Site_Base_Site_Base_Id",
                        column: x => x.Site_Base_Id,
                        principalTable: "Site_Base",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site_WhyNafta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Site_Base_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_WhyNafta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Site_WhyNafta_Site_Base_Site_Base_Id",
                        column: x => x.Site_Base_Id,
                        principalTable: "Site_Base",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Site_About_Site_Base_Id",
                table: "Site_About",
                column: "Site_Base_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Site_CertifiedProgram_Site_Base_Id",
                table: "Site_CertifiedProgram",
                column: "Site_Base_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Site_ClientAlliance_Site_Base_Id",
                table: "Site_ClientAlliance",
                column: "Site_Base_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Site_Course_Site_Base_Id",
                table: "Site_Course",
                column: "Site_Base_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Site_Facility_Site_Base_Id",
                table: "Site_Facility",
                column: "Site_Base_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Site_WhyNafta_Site_Base_Id",
                table: "Site_WhyNafta",
                column: "Site_Base_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Site_About");

            migrationBuilder.DropTable(
                name: "Site_CertifiedProgram");

            migrationBuilder.DropTable(
                name: "Site_ClientAlliance");

            migrationBuilder.DropTable(
                name: "Site_Course");

            migrationBuilder.DropTable(
                name: "Site_EvaluationResult");

            migrationBuilder.DropTable(
                name: "Site_Facility");

            migrationBuilder.DropTable(
                name: "Site_FAQ");

            migrationBuilder.DropTable(
                name: "Site_FunFact");

            migrationBuilder.DropTable(
                name: "Site_WhyNafta");

            migrationBuilder.DropTable(
                name: "Site_Base");
        }
    }
}
