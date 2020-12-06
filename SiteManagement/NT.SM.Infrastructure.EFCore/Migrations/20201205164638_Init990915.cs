using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NT.SM.Infrastructure.EFCore.Migrations
{
    public partial class Init990915 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Site_Base",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_Base", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_EvaluationResult",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_EvaluationResult", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_FAQ",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_FAQ", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_FunFact",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_FunFact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_About",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_Base_Id = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_Base_Id = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Site_Course",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_Base_Id = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasBullet = table.Column<bool>(type: "bit", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_Base_Id = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_Base_Id = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
